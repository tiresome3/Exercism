using System.Diagnostics;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        string middle = " ♡ ";
        int charsLeft = 61 - studentA.Length - studentB.Length - middle.Length;
        Trace.WriteLine(charsLeft);
        int leftBuffer = charsLeft / 2 - 1;
        int rightBuffer= charsLeft / 2 + 1;
        Trace.WriteLine(leftBuffer);
        Trace.WriteLine(rightBuffer);
        return new string(' ', leftBuffer) + studentA + middle + studentB + new string(' ', rightBuffer);
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        string result = @$"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";

        return result;
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        string result = String.Format(new CultureInfo("de-DE"), "{0} and {1} have been dating since {2:d} - that's {3:n2} hours", studentA, studentB, start, hours);
        return result;
    }
}
