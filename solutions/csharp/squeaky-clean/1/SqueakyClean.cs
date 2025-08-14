using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder identifierStringBuilder = new StringBuilder(identifier);

        identifierStringBuilder.Replace(' ', '_');

        identifierStringBuilder.Replace("\0", "CTRL");

        for (int x = 0; x < identifierStringBuilder.Length; x++)
        {
            if (identifierStringBuilder[x] == '-')
            {
                identifierStringBuilder.Remove(x, 1);
                identifierStringBuilder[x] = Char.ToUpper(identifierStringBuilder[x]);
            }
        }

        StringBuilder identifierStringBuilder2 = new StringBuilder();


        for (int x = 0; x < identifierStringBuilder.Length; x++)
        {
            if ((identifierStringBuilder[x] == '_' || Char.IsLetter(identifierStringBuilder[x])) &&
                !(identifierStringBuilder[x] >= 945 && identifierStringBuilder[x] <= 969))
            {
                identifierStringBuilder2.Append(identifierStringBuilder[x]);
            }
        }

        return identifierStringBuilder2.ToString();
    }
}
