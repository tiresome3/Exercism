using System.Text;

public class SimpleCipher
{
    public SimpleCipher()
    {
        var keySB = new StringBuilder();
        var rand = new Random();

        for (int x = 0; x < 100; x++)
        {
            keySB.Append((char)('a' + rand.Next(0, 26)));
        }
        this.key = keySB.ToString();
    }

    public SimpleCipher(string key)
    {
        this.key = key;
    }

    private string key;
    public string Key 
    {
        get
        {
            return this.key;
        }
    }

    public string Encode(string plaintext)
    {
        var tmpKey = this.Key;
        while (plaintext.Length > tmpKey.Length)
        {
            tmpKey += tmpKey;
        }
        var result = new StringBuilder();
        for (int x = 0; x < plaintext.Length; x++)
        {
            // difference of integer of plaintext char to encoded char
            var amount = (int)tmpKey[x] - 'a';
            // wrap around so we dont encode to characters other that a-z
            if ((int)plaintext[x] + amount > 'z')
            {
                amount = amount - 26;
            }
            // actually appending the encoded character to encoded string
            result.Append((char)((int)plaintext[x] + amount));
        }
        return result.ToString();
    }

    public string Decode(string ciphertext)
    {
        var tmpKey = this.Key;
        while (ciphertext.Length > tmpKey.Length)
        {
            tmpKey += tmpKey;
        }
        var result = new StringBuilder();
        for (int x = 0; x < ciphertext.Length; x++)
        {
            var amount = ((int)tmpKey[x] - 'a') * -1;
            if ((int)ciphertext[x] + amount < 'a')
            {
                amount = amount + 26;
            }
            result.Append((char)((int)ciphertext[x] + amount));
        }
        return result.ToString();
    }
}