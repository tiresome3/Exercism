using System.Diagnostics;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string intAsString = number.ToString();
        double numberDigits = intAsString.Length;
        double result = 0;

        foreach (char digit in intAsString)
        {
            result += Math.Pow((double)digit - '0', numberDigits);
        }

        if (result == (double)number)
        {
            return true;
        } else
        {
            return false;
        }
    }
}