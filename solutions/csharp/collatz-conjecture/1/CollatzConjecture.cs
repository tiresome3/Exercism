public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        int steps = 0;
        int num = number;

        while (num != 1)
        {
            steps += 1;
            if (num % 2 == 0)
            {
                num = num / 2;
            } else
            {
                num = num * 3 + 1;
            }
        }

        return steps;
    }
}