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
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Регистрация репозиториев и сервисов
        builder.Services.AddScoped<INutritionRepository, NutritionRepository>();
        builder.Services.AddScoped<INutritionService, NutritionService>();

        builder.Services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.MapControllers();

        app.Run();
    }
}