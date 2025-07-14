using BioGenomTestProject.DTOs;
using BioGenomTestProject.Entities;
using BioGenomTestProject.Repositories;

namespace BioGenomTestProject.Services;

public sealed class NutritionService(INutritionRepository nutritionRepository) : INutritionService
{
    private readonly INutritionRepository _nutritionRepository = nutritionRepository;

    public async Task<IEnumerable<NutrientResultDto>> GetDeficientNutrientsAsync(CancellationToken cancellationToken = default)
    {
        var deficientNutrients = await _nutritionRepository.GetDeficientNutrientsAsync(cancellationToken);
        return deficientNutrients.Select(MapToDto);
    }

    public async Task<IEnumerable<NutrientResultDto>> GetSufficientNutrientsAsync(CancellationToken cancellationToken = default)
    {
        var sufficientNutrients = await _nutritionRepository.GetSufficientNutrientsAsync(cancellationToken);
        return sufficientNutrients.Select(MapToDto);
    }

    public async Task<NutritionSummaryDto> GetNutritionSummaryAsync(CancellationToken cancellationToken = default)
    {
        var deficientCount = await _nutritionRepository.GetDeficientNutrientsCountAsync(cancellationToken);
        var sufficientCount = await _nutritionRepository.GetSufficientNutrientsCountAsync(cancellationToken);
        var totalCount = deficientCount + sufficientCount;

        return new NutritionSummaryDto(totalCount, deficientCount, sufficientCount);
    }

    public async Task<NutritionAssessmentDto?> GetNutritionAssessmentAsync(CancellationToken cancellationToken = default)
    {
        var assessment = await _nutritionRepository.GetNutritionAssessmentAsync(cancellationToken);
        return assessment is null ? null : MapToDto(assessment);
    }

    private static NutrientResultDto MapToDto(NutrientResult entity) => new(
            entity.Id,
            entity.Nutrient == null ? null :
            new NutrientDto(entity.Nutrient.Id, entity.Nutrient.Name, entity.Nutrient.Unit),
            entity.CurrentValue,
            entity.RecommendedMin,
            entity.RecommendedMax,
            entity.IsDeficient,
            entity.FoodSupplementAmount,
            entity.PharmaSupplementAmount);

    private static NutritionAssessmentDto MapToDto(NutritionAssessment entity) => new(
        entity.Id,
        entity.AssessmentDate,
        entity.UserId,
        entity.Results.Select(MapToDto)
    );
} 