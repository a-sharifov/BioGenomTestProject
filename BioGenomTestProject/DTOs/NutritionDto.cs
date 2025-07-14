namespace BioGenomTestProject.DTOs;

public class NutrientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
}

public class NutrientResultDto
{
    public int Id { get; set; }
    public NutrientDto Nutrient { get; set; } 
    public float CurrentValue { get; set; }
    public float RecommendedMin { get; set; }
    public float? RecommendedMax { get; set; }
    public bool IsDeficient { get; set; }
    public float? FoodSupplementAmount { get; set; }
    public float? PharmaSupplementAmount { get; set; }
}

public class NutritionSummaryDto
{
    public int TotalNutrients { get; set; }
    public int DeficientNutrients { get; set; }
    public int SufficientNutrients { get; set; }
} 