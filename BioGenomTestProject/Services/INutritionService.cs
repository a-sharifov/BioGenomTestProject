using BioGenomTestProject.DTOs;

namespace BioGenomTestProject.Services;

public interface INutritionService
{
    Task<IEnumerable<NutrientResultDto>> GetDeficientNutrientsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<NutrientResultDto>> GetSufficientNutrientsAsync(CancellationToken cancellationToken = default);
    Task<NutritionSummaryDto> GetNutritionSummaryAsync(CancellationToken cancellationToken = default);
    Task<NutritionAssessmentDto?> GetNutritionAssessmentAsync(CancellationToken cancellationToken = default);
} 