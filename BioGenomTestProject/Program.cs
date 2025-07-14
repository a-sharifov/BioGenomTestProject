using System.Threading.RateLimiting;
using BioGenomTestProject.DbContexts;
using BioGenomTestProject.Repositories;
using BioGenomTestProject.Services;
using Microsoft.EntityFrameworkCore;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.AddYamlFile("appsettings.yaml",
            optional: true, reloadOnChange: true);

        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention()
            );

        builder.Services.AddScoped<INutritionRepository, NutritionRepository>();
        builder.Services.AddScoped<INutritionService, NutritionService>();

        builder.Services.AddRateLimiter(options =>
        {
            options.GlobalLimiter =
                PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                        factory: _ => new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 20,
                            Window = TimeSpan.FromMinutes(1), 
                            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                            QueueLimit = 0
                        }));
            options.RejectionStatusCode = 429;
        });

        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseRateLimiter();

        app.MapControllers();

        app.Run();
    }
}