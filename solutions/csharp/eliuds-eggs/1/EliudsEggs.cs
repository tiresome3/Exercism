public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
    {
        var result = 0;
        var bin = Convert.ToString(encodedCount, 2);
        foreach (char el in bin)
        {
            if (el == '1')
            {
                result++;
            }
        }
        return result;
    }
}
