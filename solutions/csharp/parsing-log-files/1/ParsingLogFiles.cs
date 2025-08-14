using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        Regex pattern = new Regex(@"^\[TRC\]|^\[DBG\]|^\[INF\]|^\[WRN\]|^\[ERR\]|^\[FTL\]");
        return pattern.IsMatch(text);
    }

    public string[] SplitLogLine(string text)
    {
        Regex pattern = new Regex(@"<[=,^,-]*>");
        return pattern.Split(text);
    }

    public int CountQuotedPasswords(string lines)
    {
        Regex pattern = new Regex("\".*[Pp][Aa][Ss][Ss][Ww][Oo][Rr][Dd].*\"");
        // Trace.WriteLine(pattern.Count(lines));
        return pattern.Count(lines);
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line[0-9]*", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var result = new List<string>();
        Regex pattern = new Regex("[Pp][Aa][Ss][Ss][Ww][Oo][Rr][Dd][A-Z,a-z,0-9]+");
        foreach (string line in lines) {
            if (pattern.IsMatch(line))
            {
                result.Add(pattern.Match(line).Value + ": " + line);
            } else
            {
                result.Add("--------: " + line);
            }
        }
        return result.ToArray();
    }
}
