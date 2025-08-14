using System.Diagnostics;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private int allergyScore;
    private string allergyScoreString;
    public Allergies(int mask)
    {
        this.allergyScore = mask;
        this.allergyScoreString = Convert.ToString(mask, toBase: 2);
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        if (((int)allergen + 1) > this.allergyScoreString.Length)
        {
            return false;
        } else if (allergyScoreString[allergyScoreString.Length - ((int)allergen + 1)] == '1')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Allergen[] List()
    {
        List<Allergen> result = new List<Allergen> { };
        var allergies = Enum.GetValues(typeof(Allergen));
        foreach (var allergie in allergies)
        {
            if (IsAllergicTo((Allergen)allergie))
            {
                result.Add((Allergen)allergie);
            }
        }
        return result.ToArray();
    }
}