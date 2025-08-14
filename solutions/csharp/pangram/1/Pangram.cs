using System.Diagnostics;

using Xunit.Runner.Common;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        bool[] checkList = new bool[26] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
        int result = 0;
        foreach (char letter in input)
        {
            if (alphabet.Contains(Char.ToLower(letter)))
            {
                checkList[alphabet.IndexOf(Char.ToLower(letter))] = true;
            }
        }
        foreach (bool letter in checkList)
        {
            if (letter)
            {
                result++;
            }
        }
        if (result == 26)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
