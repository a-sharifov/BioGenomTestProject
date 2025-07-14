namespace BioGenomTestProject.Entities;

public class NutrientResult
{
    public int Id { get; private set; }
    public int NutrientId { get; private set; }
    public Nutrient Nutrient { get; private set; }
    public float CurrentValue { get; private set; }
    public float RecommendedMin { get; private set; }
    public float? RecommendedMax { get; private set; }
    public bool IsDeficient { get; private set; }
    public float? FoodSupplementAmount { get; private set; }
    public float? PharmaSupplementAmount { get; private set; }
    public int AssessmentId { get; private set; }
    public NutritionAssessment Assessment { get; private set; } 

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private NutrientResult() { } // Ef require
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public NutrientResult(int id, int nutrientId, Nutrient nutrient, float currentValue,
                          float recommendedMin, float? recommendedMax, bool isDeficient,
                          float? foodSupplementAmount, float? pharmaSupplementAmount,
                          int assessmentId, NutritionAssessment assessment)
    {
        Id = id;
        NutrientId = nutrientId;
        Nutrient = nutrient;
        CurrentValue = currentValue;
        RecommendedMin = recommendedMin;
        RecommendedMax = recommendedMax;
        IsDeficient = isDeficient;
        FoodSupplementAmount = foodSupplementAmount;
        PharmaSupplementAmount = pharmaSupplementAmount;
        AssessmentId = assessmentId;
        Assessment = assessment;
    }

}
