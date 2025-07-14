namespace BioGenomTestProject.Entities;

public class Nutrient
{
    public int Id { get; private set; }
    public string Name { get; private set; }          
    public string Unit { get; private set; }

    public ICollection<NutrientResult> Results { get; set; } = [];

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Nutrient() { } // Ef require
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Nutrient(int id, string name, string unit) =>
        (Id, Name, Unit) = (id, name, unit);
}
