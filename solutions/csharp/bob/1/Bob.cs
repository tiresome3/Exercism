public static class Bob
{
    public static string Response(string statement)
    {
        bool questionmark;
        bool allUpperCase = true;
        bool allWhiteSpaces = true;

        if (statement.Length == 0)
        {
            return "Fine. Be that way!";
        }

        bool anyLetter = false;
      
        for (int x = 0; x < statement.Length; x++)
        {
            if (Char.IsLetter(statement[x]) && Char.IsLower(statement[x]))
            {
                allUpperCase = false;
            }
            if (Char.IsLetter(statement[x]))
            {
                anyLetter = true;
            }
            if (!Char.IsWhiteSpace(statement[x]))
            {
                allWhiteSpaces = false;
            }
        }
        if (!anyLetter)
        {
            allUpperCase = false;
        }

        if (allWhiteSpaces)
        {
            return "Fine. Be that way!";
        }

        String statementTrimmedEnd = statement.TrimEnd();

        if (statementTrimmedEnd[statementTrimmedEnd.Length - 1] == '?')
        {
            questionmark = true;
        } else
        {
            questionmark = false;
        }
 

        if (questionmark && !allUpperCase)
        {
            return "Sure.";
        } else if (allUpperCase && questionmark)
        {
            return "Calm down, I know what I'm doing!";
        } else if (allUpperCase)
        {
            return "Whoa, chill out!";
        } else
        {
            return "Whatever.";
        }
    }
}