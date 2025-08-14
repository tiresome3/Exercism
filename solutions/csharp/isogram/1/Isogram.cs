public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var mem = new List<char>();
        for (int x = 0; x < word.Length; x++)
        {
            var letter = char.ToLower(word[x]);
            if (Char.IsLetter(letter) && mem.Contains(letter)) 
            {
                return false;
            } else
            {
                mem.Add(letter);
            }
        }
        return true;
    }
}
