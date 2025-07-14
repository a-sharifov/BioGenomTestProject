using BioGenomTestProject.DTOs;
using BioGenomTestProject.Entities;

namespace BioGenomTestProject.Services;

public interface INutritionService
{
    Task<IEnumerable<NutrientResultDto>> GetDeficientNutrientsAsync();
    Task<IEnumerable<NutrientResultDto>> GetSufficientNutrientsAsync();
    Task<NutritionSummaryDto> GetNutritionSummaryAsync();
    Task<NutritionAssessmentDto?> GetNutritionAssessmentAsync();
} 