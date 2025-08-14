public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimiter)
    {
        int indexOfDelimiter = str.IndexOf(delimiter);
        return str.Substring(indexOfDelimiter + delimiter.Length);
    }

    public static string SubstringBetween(this string str, string delimiter1, string delimiter2)
    {
        int indexOfDelimiter1 = str.IndexOf(delimiter1);
        int indexOfDelimiter2 = str.IndexOf(delimiter2);
        int endOfDelimiter1 = indexOfDelimiter1 + delimiter1.Length;
        return str.Substring(endOfDelimiter1, indexOfDelimiter2 - endOfDelimiter1);
    }

    public static string Message(this string log)
    {
        return log.SubstringAfter(": ");
    }

    public static string LogLevel(this string log)
    {
        return log.SubstringBetween("[", "]");
    }
}