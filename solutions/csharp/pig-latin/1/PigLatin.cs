public static class PigLatin
{
    public static string Translate(string word)
    {
        String[] wordsArray = word.Split(' ');
        String resultString = "";

        foreach (string wor in wordsArray)
        {
            resultString = resultString + " " + TranslateHelp(wor);
        }
        return resultString.TrimStart();
    }
    public static string TranslateHelp(string word) { 
        String vowels = "aeiou";
        // first letter vowel
        if (vowels.Contains(word[0]) || word.Substring(0, 2) == "xr" || word.Substring(0, 2) == "yt") // rule 1
        {
            return word + "ay";
        }
        else // first letter consonant
        {
            int x = 1;
            while (x < word.Length)
            {
                if (word[x] == 'u' && word[x - 1] == 'q') // rule 3
                {
                    return word.Substring(x + 1) + word.Substring(0, x + 1) + "ay";
                }
                if (vowels.Contains(word[x])) // rule 2
                {
                    return word.Substring(x) + word.Substring(0, x) + "ay";
                }
                if (word[x] == 'y') // rule 4
                {
                    return word.Substring(x) + word.Substring(0, x) + "ay";
                }
                x++;
            }
            return word;
        }
    }
}