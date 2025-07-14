namespace BioGenomTestProject.DTOs;

public sealed record NutrientResultDto(
    int Id,
    NutrientDto? Nutrient,
    float CurrentValue,
    float RecommendedMin,
    float? RecommendedMax,
    bool IsDeficient,
    float? FoodSupplementAmount,
    float? PharmaSupplementAmount);
