public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int hDistance = 0;
        if (firstStrand.Length == secondStrand.Length)
        {
            for (int x = 0; x < firstStrand.Length; x++)
            {
                if (firstStrand[x] != secondStrand[x])
                {
                    hDistance ++;
                }
            }
        } else
        {
            throw new ArgumentException();
        }
        return hDistance;
    }
}