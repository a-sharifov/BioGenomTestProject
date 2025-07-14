using BioGenomTestProject.Entities;

namespace BioGenomTestProject.Repositories;

public interface INutritionRepository
{
    Task<NutritionAssessment?> GetNutritionAssessmentAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<NutrientResult>> GetDeficientNutrientsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<NutrientResult>> GetSufficientNutrientsAsync(CancellationToken cancellationToken = default);
    Task<int> GetDeficientNutrientsCountAsync(CancellationToken cancellationToken = default);
    Task<int> GetSufficientNutrientsCountAsync(CancellationToken cancellationToken = default);
} 