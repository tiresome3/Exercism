public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        var aliquotSum = GetAliquotSum(number);
        if (number < aliquotSum)
        {
            return Classification.Abundant;
        } else if (number > aliquotSum)
        {
            return Classification.Deficient;
        } else
        {
            return Classification.Perfect;
        }

    }
    private static int GetAliquotSum(int number)
    {
        var result = new List<int>();
        for (int x = 1; x < number; x++)
        {
            if (number % x == 0)
            {
                result.Add(x);
            }
        }
        return result.Sum();
    }
}
