public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        var range = Enumerable.Range(1, max).ToArray();
        var result = 0;
        foreach (int number in range)
        {
            result += number;
        }
        return (int)Math.Pow(result, 2);
    }

    public static int CalculateSumOfSquares(int max)
    {
        var range = Enumerable.Range(1, max).ToArray();
        var result = 0;
        for (int x = 0; x < range.Length; x++)
        {
            result += (int)Math.Pow(range[x], 2);
        }
        return result;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}