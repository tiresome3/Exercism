using System.Text;

public static class RotationalCipher
{
    static char[] alphabet = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder textSB = new StringBuilder(text);
        for (int x = 0; x < textSB.Length; x++)
        {
            if (Char.IsLetter(textSB[x]))
            {
                bool isUpper;
                if (Char.IsUpper(textSB[x]))
                {
                    isUpper = true;
                }
                else
                {
                    isUpper = false;
                }
                char curChar = Char.ToLower(textSB[x]);

                int newIndex = Array.IndexOf(alphabet, curChar) + shiftKey;
                if (newIndex > alphabet.Length - 1)
                {
                    newIndex = newIndex - alphabet.Length;
                }

                if (isUpper)
                {
                    textSB[x] = Char.ToUpper(alphabet[newIndex]);
                }
                else
                {
                    textSB[x] = alphabet[newIndex];
                }
            }
        }
        return textSB.ToString();

    }
}