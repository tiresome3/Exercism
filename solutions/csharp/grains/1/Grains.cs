public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (n == 1) return 1;
        else if (n == 2) return 2;
        else
        {
            ulong result = 2;
            for (int x = 1; x < n - 1; x++)
            {
                result = result * 2;
            }
            return result;
        }
    }

    public static ulong Total()
    {
        ulong result = 0;
        for (int x = 1; x < 65; x++)
        {
            result += Square(x);
        }
        return result;
    }
}