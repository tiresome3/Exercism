public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var result = new Dictionary<string, int>();
        foreach (var keyValue in old)
        {
            foreach (string letter in keyValue.Value)
            {
                result.Add(letter.ToLower(), keyValue.Key);
            }
        }
        return result;
    }
}