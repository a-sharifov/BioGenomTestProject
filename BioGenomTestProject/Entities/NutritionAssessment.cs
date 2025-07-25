﻿namespace BioGenomTestProject.Entities;

public class NutritionAssessment
{
    public int Id { get; private set; }
    public DateTime AssessmentDate { get; private set; }
    public int UserId { get; private set; }
    public ICollection<NutrientResult> Results { get; set; } = [];

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private NutritionAssessment() { } // Ef require
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public NutritionAssessment(int id, int userId, DateTime assessmentDate) =>
        (Id, UserId, AssessmentDate) = (id, userId, assessmentDate);
}
