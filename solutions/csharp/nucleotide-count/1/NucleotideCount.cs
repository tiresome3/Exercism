public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var result = new Dictionary<char, int> 
        {
            { 'A', 0},
            { 'C', 0},
            { 'G', 0},
            { 'T', 0}
        };
        foreach (char nucleotide in sequence)
        {
            if (result.ContainsKey(nucleotide)) {
                result[nucleotide]++;
            } else
            {
                throw new ArgumentException();
            }
        }
        return result;
    }
}