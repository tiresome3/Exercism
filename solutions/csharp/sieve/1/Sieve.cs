using System.Diagnostics;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        var potNumbers = Enumerable.Range(2, limit - 1).ToArray();
        var marks = new bool[potNumbers.Length];

        for (int x = 0; x < potNumbers.Length; x++ )
        {
            // prime number found
            if (!marks[x])
            {
                var currentNumber = potNumbers[x];
                for (int y = x + 1; y < potNumbers.Length; y++)
                {
                    // mark multiples as NOT prime
                    if (potNumbers[y] % currentNumber == 0)
                    {
                        marks[y] = true;
                    }

                }
            }
        }
        var result = new List<int>();
        for (int x = 0; x < potNumbers.Length; x++ )
        {
            if (!marks[x])
            {
                result.Add(potNumbers[x]);
            }
        }
        return result.ToArray();
    }
}