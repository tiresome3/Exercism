using System.Text;

public static class Say
{
    private static string[] zeroToNine = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    private static string[] tenToNineteen = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    private static string[] SmallMultiplier = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
    public static string InEnglish(long number)
    {
        if (number < 0 || number > 999999999999)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (number == 0)
        {
            return "zero";
        }
        var result = new StringBuilder();

        if (number > 999999999)
        {
            result.Append(Hundrets(number / 1000000000) + " billion");
            if ((number %  1000000000) != 0)
            {
                result.Append(" ");
            }
        } 
        if (((number %  1000000000) / 1000000) != 0)
        {
            result.Append(Hundrets((number %  1000000000) / 1000000) + " million");
            if ((number %  1000000) != 0)
            {
                result.Append(" ");
            }
        } 
        if (((number % 1000000) / 1000) != 0)
        {
            result.Append(Hundrets((number %  1000000) / 1000) + " thousand");
            if ((number %  1000) != 0)
            {
                result.Append(" ");
            }
        } 
        if (number > 0)
        {
            result.Append(Hundrets(number %  1000));
        }
        return result.ToString();
    }
    private static string Hundrets(long number)
    {
        var oneMulti = number % 10;
        var twoMulti = (number % 100) / 10;
        var threeMulti = number / 100;
        var tens = number % 100;

        var result = new StringBuilder();
        if (threeMulti != 0)
        {
            result.Append(zeroToNine[threeMulti] + " hundred");
            if (twoMulti != 0 || oneMulti != 0)
            {
                result.Append(" ");
            }
        }
        if (tens > 0 && tens < 10)
        {
            result.Append(zeroToNine[oneMulti]);
        } else if (tens > 9 && tens < 20)
        {
            result.Append(tenToNineteen[tens % 10]);
        } else
        {
            if (twoMulti != 0)
            {
                result.Append(SmallMultiplier[twoMulti]);
            }
            if (oneMulti != 0 && twoMulti != 0)
            {
                result.Append("-");
            }
            if (oneMulti != 0)
            {
                result.Append(zeroToNine[oneMulti]);
            }
        }
        return result.ToString();
    }
}