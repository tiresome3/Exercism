using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var result = new char[input.Length];
        for (int x = 0; x < input.Length; x++)
        {
            result[input.Length - 1 - x] = input[x];
        }
        return new string(result);
    }
}