using BioGenomTestProject.DTOs;
using BioGenomTestProject.Entities;
using BioGenomTestProject.Repositories;

namespace BioGenomTestProject.Services;

public class NutritionService(INutritionRepository nutritionRepository) : INutritionService
{
    private readonly INutritionRepository _nutritionRepository = nutritionRepository;

    public async Task<IEnumerable<NutrientResultDto>> GetDeficientNutrientsAsync()
    {
        var deficientNutrients = await _nutritionRepository.GetDeficientNutrientsAsync();
        return deficientNutrients.Select(MapToDto);
    }

    public async Task<IEnumerable<NutrientResultDto>> GetSufficientNutrientsAsync()
    {
        var sufficientNutrients = await _nutritionRepository.GetSufficientNutrientsAsync();
        return sufficientNutrients.Select(MapToDto);
    }

    public async Task<NutritionSummaryDto> GetNutritionSummaryAsync()
    {
        var deficientCount = await _nutritionRepository.GetDeficientNutrientsCountAsync();
        var sufficientCount = await _nutritionRepository.GetSufficientNutrientsCountAsync();
        var totalCount = deficientCount + sufficientCount;

        return new NutritionSummaryDto
        {
            TotalNutrients = totalCount,
            DeficientNutrients = deficientCount,
            SufficientNutrients = sufficientCount,
        };
    }

    public Task<NutritionAssessment?> GetNutritionAssessmentAsync()
    {
        return _nutritionRepository.GetNutritionAssessmentAsync();
    }

    private static NutrientResultDto MapToDto(Entities.NutrientResult entity)
    {
        return new NutrientResultDto
        {
            Id = entity.Id,
            Nutrient = new NutrientDto
            {
                Id = entity.Nutrient.Id,
                Name = entity.Nutrient.Name,
                Unit = entity.Nutrient.Unit
            } ,
            CurrentValue = entity.CurrentValue,
            RecommendedMin = entity.RecommendedMin,
            RecommendedMax = entity.RecommendedMax,
            IsDeficient = entity.IsDeficient,
            FoodSupplementAmount = entity.FoodSupplementAmount,
            PharmaSupplementAmount = entity.PharmaSupplementAmount
        };
    }
} 