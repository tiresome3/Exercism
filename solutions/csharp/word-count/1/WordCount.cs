using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var result = new Dictionary<string, int>();
        // split by any whitespace, any punctuation except '''
        var pattern = new Regex(@"[\^,\$,\s,\p{P}-[']]]*");
        var words = pattern.Split(phrase);
        for (int x = 0; x < words.Length; x++)
        {
            // trim ''' that are not used for contractions and are therefore at beginning or end of word
            // convert words to lowercase so we dont count words multiple times just because they are upper case
            var word = words[x].Trim( '\'').ToLower();
            // since we trimmed ''' there can be words that are just "", so ignore them
            if (word != "")
            {
                if (!result.Keys.Contains(word))
                {
                    result.Add(word, 1);
                }
                else
                {
                    result[word]++;
                }
            }
        }
        return result;
    }
}