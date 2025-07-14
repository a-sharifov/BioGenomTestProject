namespace BioGenomTestProject.DTOs;

public sealed record NutritionAssessmentDto(
    int Id,
    DateTime AssessmentDate,
    int UserId,
    IEnumerable<NutrientResultDto> Results
); 