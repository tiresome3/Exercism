using System.Diagnostics;
using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var noDash = Regex.Replace(number, @"-", "");
        Regex pattern = new Regex(@"^[0-9]{9}[0-9,X]$");
        if (!pattern.IsMatch(noDash))
        {
            return false;
        } else
        {
            int checkDigit;
            if (noDash[9] == 'X')
            {
                checkDigit = 10;
            } else
            {
                checkDigit = int.Parse(noDash[9].ToString());
            }
            return (int.Parse(noDash[0].ToString()) * 10 + int.Parse(noDash[1].ToString()) * 9 + int.Parse(noDash[2].ToString()) * 8 + int.Parse(noDash[3].ToString()) * 7 + int.Parse(noDash[4].ToString()) * 6 + int.Parse(noDash[5].ToString()) * 5 + int.Parse(noDash[6].ToString()) * 4 + int.Parse(noDash[7].ToString()) * 3 + int.Parse(noDash[8].ToString()) * 2  + checkDigit * 1) % 11 == 0;
        }
    }
}