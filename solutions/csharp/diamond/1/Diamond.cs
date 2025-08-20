using System.Diagnostics;
using System.Text;

public static class Diamond
{
    private static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string Make(char target)
    {
        var index = alphabet.IndexOf(target);
        var result = new StringBuilder();

        // if target is "A" just return string "A"
        if (index == 0)
        {
            return "A";
        }

        // assemble first half of diamond
        for (int x = 0; x <= index; x++)
        {
            var line = new StringBuilder();
            line.Append(new string(' ', index - x));
            line.Append(alphabet[x]);
            // no second letter and middle whitespaces for first row
            if (x != 0)
            {
                line.Append(new string(' ', x * 2 - 1));
                line.Append(alphabet[x]);
            }
            line.Append(new string(' ', index - x));
            line.Append("\n");
            result.Append(line);
        }
        // assemble first half of diamond
        for (int x = index - 1; x >= 0; x--)
        {
            var line = new StringBuilder();
            line.Append(new string(' ', index - x));
            line.Append(alphabet[x]);
            // no second letter and middle whitespaces for last row
            if (x != 0)
            {
                line.Append(new string(' ', x * 2 - 1));
                line.Append(alphabet[x]);
            }
            line.Append(new string(' ', index - x));
            // dont add newline at the end of last row
            if (x != 0)
            {
                line.Append("\n");
            }
            result.Append(line);
        }
        return result.ToString();
    }
}