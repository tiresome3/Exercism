using System.Collections.Generic;

public static class BottleSong
{
    private static string[] numbersInWords = { "no", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> result = new List<string>();
        int CurrentBottles = startBottles;
        for (int x = takeDown; x > 0; x--)
        {
            switch (CurrentBottles)
            {
                case 1:
                    result.Add($"{numbersInWords[CurrentBottles]} green bottle hanging on the wall,");
                    result.Add($"{numbersInWords[CurrentBottles]} green bottle hanging on the wall,");
                    result.Add("And if one green bottle should accidentally fall,");
                    CurrentBottles--;
                    result.Add($"There'll be {numbersInWords[CurrentBottles].ToLower()} green bottles hanging on the wall.");
                    break;
                case 2:
                    result.Add($"{numbersInWords[CurrentBottles]} green bottles hanging on the wall,");
                    result.Add($"{numbersInWords[CurrentBottles]} green bottles hanging on the wall,");
                    result.Add("And if one green bottle should accidentally fall,");
                    CurrentBottles--;
                    result.Add($"There'll be {numbersInWords[CurrentBottles].ToLower()} green bottle hanging on the wall.");
                    break;
                default:
                    result.Add($"{numbersInWords[CurrentBottles]} green bottles hanging on the wall,");
                    result.Add($"{numbersInWords[CurrentBottles]} green bottles hanging on the wall,");
                    result.Add("And if one green bottle should accidentally fall,");
                    CurrentBottles--;
                    result.Add($"There'll be {numbersInWords[CurrentBottles].ToLower()} green bottles hanging on the wall.");
                    break;
            }
            if (x != 1)
            {
                result.Add("");
            }
        }
        return result.ToArray();
    }
}
