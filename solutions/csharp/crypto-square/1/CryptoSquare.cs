using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        var result = new StringBuilder();
        for (int x = 0; x < plaintext.Length; x++)
        {
            var curChar = plaintext[x];
            if(!(Char.IsWhiteSpace(curChar) || Char.IsPunctuation(curChar)))
            {
                result.Append(curChar);
            }
        }
        return result.ToString().ToLower();
    }

    public static string[] PlaintextSegments(string plaintext)
    {
        if (plaintext == "") return new string[] { "" };
        var textLength = plaintext.Length;
        var c = 1;
        int r;
        var r1 = c;
        var r2 = c - 1;
        while (r1 * c < textLength && r2 * c < textLength)
        {
            c++;
            r1 = c;
            r2 = c - 1;
        }
        if (r2 * c >= textLength) r = r2; else r = r1;

        var result = new string[r];
        var extendedPlaintext = new StringBuilder(plaintext).Append(new string(' ', c * r - textLength)).ToString();
        for (int x = 0; x < r; x++)
        {
            result[x] = extendedPlaintext.Substring(x * c, c);
        }
        return result;
    }

    public static string Encoded(string[] plaintext)
    {
        var c = plaintext[0].Length;
        var r = plaintext.Length;
        var encArray = new string[c];
        for (int x = 0; x < c; x++)
        {
            var newRow = new StringBuilder();
            for (int y = 0; y < r; y++)
            {
                newRow.Append(plaintext[y][x]);
            }
            encArray[x] = newRow.ToString();
        }
        return string.Join(" ", encArray);
    }

    public static string Ciphertext(string plaintext)
    {
        var normalized = NormalizedPlaintext(plaintext);
        var segmented = PlaintextSegments(normalized);
        var result = Encoded(segmented);
        return result;
    }
}