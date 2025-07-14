namespace BioGenomTestProject.DbContexts;
using BioGenomTestProject.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Nutrient> Nutrients { get; set; }
    public DbSet<NutritionAssessment> NutritionAssessments { get; set; }
    public DbSet<NutrientResult> NutrientResults { get; set; }
}