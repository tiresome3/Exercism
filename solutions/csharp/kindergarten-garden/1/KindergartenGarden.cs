using System.Data;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}


public class KindergartenGarden
{
    static string[] kids = new string[12] { "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry" };

    Dictionary<Char, Plant> plantShort = new Dictionary<Char, Plant>
    {
        {'V', Plant.Violets },
        {'R', Plant.Radishes },
        {'C', Plant.Clover },
        {'G', Plant.Grass }
    };

    private string[] rows;

    public KindergartenGarden(string diagram)
    {
        this.rows = diagram.Split("\n");
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var ind = Array.IndexOf(kids, student);
        var ind1 = ind * 2;
        var ind2 = ind * 2 + 1;

        return new List<Plant> { plantShort[rows[0][ind1]], plantShort[rows[0][ind2]], plantShort[rows[1][ind1]], plantShort[rows[1][ind2]]};
    }
}