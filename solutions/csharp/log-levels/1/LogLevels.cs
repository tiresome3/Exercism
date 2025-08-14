static class LogLine
{
    public static string Message(string logLine)
    {
        String stringNoPrefix = logLine.Replace("[ERROR]:", "").Replace("[WARNING]:", "").Replace("[INFO]:", "");
        String stringNoWhitespace = stringNoPrefix.Trim();
        return stringNoWhitespace;
    }

    public static string LogLevel(string logLine)
    {
        int indexCloseBracket = logLine.IndexOf("]") - 1;
        return logLine.Substring(1, indexCloseBracket).ToLower();
    }

    public static string Reformat(string logLine)
    {
        String logLevel = LogLevel(logLine);
        String logMessage = Message(logLine);
        String reformattedString = logMessage + " (" + logLevel + ")";
        return reformattedString;
    }
}
