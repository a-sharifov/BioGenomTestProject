using BioGenomTestProject.DbContexts;
using BioGenomTestProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioGenomTestProject.Repositories;

public class NutritionRepository(AppDbContext context) : INutritionRepository
{
    private readonly AppDbContext _context = context;

    public async Task<NutritionAssessment?> GetNutritionAssessmentAsync(
        CancellationToken cancellationToken = default) => 
        await _context.NutritionAssessments
            .Include(na => na.Results)
            .ThenInclude(nr => nr.Nutrient)
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<NutrientResult>> GetDeficientNutrientsAsync(
        CancellationToken cancellationToken = default) => 
        await _context.NutrientResults
            .Include(nr => nr.Nutrient)
            .Where(nr => nr.IsDeficient)
            .ToListAsync();

    public async Task<IEnumerable<NutrientResult>> GetSufficientNutrientsAsync(
        CancellationToken cancellationToken = default) => 
        await _context.NutrientResults
            .Include(nr => nr.Nutrient)
            .Where(nr => !nr.IsDeficient)
            .ToListAsync();

    public async Task<int> GetDeficientNutrientsCountAsync(
        CancellationToken cancellationToken = default) => 
        await _context.NutrientResults
            .CountAsync(nr => nr.IsDeficient);

    public async Task<int> GetSufficientNutrientsCountAsync(
        CancellationToken cancellationToken = default) => 
        await _context.NutrientResults
            .CountAsync(nr => !nr.IsDeficient);
} 