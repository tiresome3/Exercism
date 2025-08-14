public static class ScrabbleScore
{
    public static int Score(string input)
    {
        Dictionary<string, int> scores = new Dictionary<string, int> {
            {"aeioulnrst", 1},
            {"dg", 2},
            {"bcmp", 3},
            {"fhvwy", 4},
            {"k", 5},
            {"jx", 8},
            {"qz", 10}
        };

        int res = 0;

        for(int x = 0; x < input.Length; x++)
        {
            foreach (string category in scores.Keys)
            {
                if (category.Contains(Char.ToLower(input[x]))){
                    res += scores[category];
                }
            }
        }
        return res;
    }
}