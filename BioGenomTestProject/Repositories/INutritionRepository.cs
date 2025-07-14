using BioGenomTestProject.Entities;

namespace BioGenomTestProject.Repositories;

public interface INutritionRepository
{
    Task<NutritionAssessment?> GetNutritionAssessmentAsync();
    Task<IEnumerable<NutrientResult>> GetDeficientNutrientsAsync();
    Task<IEnumerable<NutrientResult>> GetSufficientNutrientsAsync();
    Task<int> GetDeficientNutrientsCountAsync();
    Task<int> GetSufficientNutrientsCountAsync();
} 