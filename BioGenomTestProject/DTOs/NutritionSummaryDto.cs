namespace BioGenomTestProject.DTOs;

public sealed record NutritionSummaryDto(
    int TotalNutrients,
    int DeficientNutrients,
    int SufficientNutrients);
