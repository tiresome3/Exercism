using System.Text;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length < 1)
        {
            return new string[] { };
        }
        var result = new string[subjects.Length];

        for (int x = 0; x < subjects.Length -1; x++)
        {
            result[x] = $"For want of a {subjects[x]} the {subjects[x + 1]} was lost.";
        }

        result[subjects.Length - 1] = $"And all for the want of a {subjects[0]}.";

        return result;
    }
}