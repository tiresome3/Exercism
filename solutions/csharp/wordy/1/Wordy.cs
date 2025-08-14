using System.Diagnostics;
using System.Text.RegularExpressions;

public static class Wordy
{
    public static int Answer(string question)
    {
        Regex patternOne = new Regex(@"^What is (?<nOne>[0-9]+)\?$");
        Regex patternTwo = new Regex(@"^What is (?<nOne>-?[0-9]+) (?<oOne>plus|minus|multiplied by|divided by) (?<nTwo>-?[0-9]+)\?$");
        Regex patternThree = new Regex(@"^What is (?<nOne>-?[0-9]+) (?<oOne>plus|minus|multiplied by|divided by) (?<nTwo>-?[0-9]+) (?<oTwo>plus|minus|multiplied by|divided by) (?<nThree>-?[0-9]+)\?$");
        if (patternOne.IsMatch(question))
        {
            Match match = patternOne.Match(question);
            return int.Parse(match.Groups["nOne"].Value);
        }
        else if (patternTwo.IsMatch(question))
        {
            Match match = patternTwo.Match(question);
            int nOne = int.Parse(match.Groups["nOne"].Value);
            int nTwo = int.Parse(match.Groups["nTwo"].Value);
            string oOne = match.Groups["oOne"].Value;
            return calcu(nOne, nTwo, oOne);
        } else if (patternThree.IsMatch(question))
        {
            Match match = patternThree.Match(question);
            int nOne = int.Parse(match.Groups["nOne"].Value);
            int nTwo = int.Parse(match.Groups["nTwo"].Value);
            int nThree = int.Parse(match.Groups["nThree"].Value);
            string oOne = match.Groups["oOne"].Value;
            string oTwo = match.Groups["oTwo"].Value;
            return calcu(calcu(nOne, nTwo, oOne), nThree, oTwo);
        } else
        {
            throw new ArgumentException();
        }
    }
    public static int calcu(int numberOne, int numberTwo, string Operator)
    {
        switch (Operator)
        {
            case "plus":
                return numberOne + numberTwo;
            case "minus":
                return numberOne - numberTwo;
            case "multiplied by":
                return numberOne * numberTwo;
            default:
                return numberOne / numberTwo;
        }
    }
}