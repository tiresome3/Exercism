public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var result = new List<string>();
        string[] operations = new string[] { "wink", "double blink", "close your eyes", "jump", "reverse"};
        var y = 0;
        string binary = Convert.ToString(commandValue, 2);


        for (int x = binary.Length - 1; x >= 0; x--)
        {
            if (binary[x] == '1')
            {
                if (operations[y] != "reverse")
                {
                    result.Add(operations[y]);
                } else
                {
                    result.Reverse();
                }
            }
            y++;
        }
        return result.ToArray();
    }
}
