using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string strand)
    {
        var result = new StringBuilder();
        foreach (char letter in strand)
        {
            switch(letter)
            {
                case 'G':
                    result.Append("C");
                    break;
                case 'C':
                    result.Append("G");
                    break;
                case 'T':
                    result.Append("A");
                    break;
                case 'A':
                    result.Append("U");
                    break;
            }
        }
        return result.ToString();
    }
}