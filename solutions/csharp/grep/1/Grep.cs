using System.Diagnostics;
using System.Text;
using System.Transactions;



public static class Grep
{
    [Flags]
    enum GrepFlags
    {
       None = 0b00000000,
       LineNumbers = 0b00000001,
       OnlyFiles = 0b00000010,
       CaseInsensitive = 0b00000100,
       Invert = 0b00001000,
       EntireLine = 0b00010000
    }
    public static string Match(string pattern, string flags, string[] files)
    {
        var flagsSet = ParseFlags(flags);

        var result = new StringBuilder();
        foreach (string file in files)
        {
            var lines = File.ReadAllLines(file);
            var lineNumber = 0;
            foreach (string line in lines)
            {
                lineNumber++;
                var lineContains = new bool();
                var tmpLine = line;
                var tmpPattern = pattern;
                // if CaseInsensitive Flag is set (-i) lower line and pattern temporarily
                if ((GrepFlags.CaseInsensitive & flagsSet) == GrepFlags.CaseInsensitive)
                {
                    tmpLine = tmpLine.ToLower();
                    tmpPattern = tmpPattern.ToLower();
                }
                // if EntrieLine Flag is set (-x) compare entire line to pattern
                if ((GrepFlags.EntireLine & flagsSet) == GrepFlags.EntireLine)
                {
                    lineContains = tmpLine == tmpPattern;
                } else
                {
                    lineContains = tmpLine.Contains(tmpPattern);
                }
                // if Inverted Flag is set (-v) 
                if ((GrepFlags.Invert & flagsSet) == GrepFlags.Invert)
                {
                    lineContains = !lineContains;
                }
                if (lineContains)
                {
                    var newLine = new StringBuilder();
                    // if there is already a line in result append \n to old line
                    if (result.Length > 0)
                    {
                        newLine.Append("\n");
                    }
                    // if its multiple files prepend filename
                    if (files.Length > 1)
                    {
                        newLine.Append($"{file}:");
                    }
                    // if LineNumbers Flag is set (-n) prepend line numbers
                    if ((GrepFlags.LineNumbers & flagsSet) == GrepFlags.LineNumbers)
                    {
                        newLine.Append($"{lineNumber}:");
                    }
                    // append actual line containing pattern
                    newLine.Append(line);
                    // if OnlyFiles Flag is set (-l) append only file name
                    if ((GrepFlags.OnlyFiles & flagsSet) == GrepFlags.OnlyFiles)
                    {
                        newLine = new StringBuilder();
                        if (!result.ToString().Contains(file) && result.Length == 0)
                        {
                            newLine.Append($"{file}");
                        } else if (!result.ToString().Contains(file) && result.Length != 0) 
                        {
                            newLine.Append($"\n{file}");
                        }
                    }
                    result.Append(newLine);
                }
            }
        }
        return result.ToString();
    }
    private static GrepFlags ParseFlags(string flags)
    {
        var flagArray = flags.Split(" ");
        var flagList = new List<GrepFlags>();
        var result = GrepFlags.None;
        foreach (string flag in flagArray)
        {
            switch (flag)
            {
                case "-n":
                    result = result | GrepFlags.LineNumbers;
                    break;
                case "-l":
                    result = result | GrepFlags.OnlyFiles;
                    break;
                case "-i":
                    result = result | GrepFlags.CaseInsensitive;
                    break;
                case "-v":
                    result = result | GrepFlags.Invert;
                    break;
                case "-x":
                    result = result | GrepFlags.EntireLine;
                    break;
            }
        }
        return result;
    }
}