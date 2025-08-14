using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder phraseNoPunctiation = new StringBuilder();
        for (int x = 0; x < phrase.Length; x++)
        {
            if ( phrase[x] == '-' || !(Char.IsPunctuation(phrase[x])))
            {
                phraseNoPunctiation.Append(phrase[x]);
            }
        }
        string phraseNP = phraseNoPunctiation.ToString();
        result.Append(Char.ToUpper(phraseNP[0]));
        for (int x = 0; x < phraseNP.Length; x++)
        {
            if ((phraseNP[x] == ' ' || phraseNP[x] == '-') && Char.IsLetter(phraseNP[x + 1]))
            {
                result.Append(Char.ToUpper(phraseNP[x + 1]));
            }
        }
        return result.ToString();
    }
}