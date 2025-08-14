public static class ResistorColorTrio
{
    public static Dictionary<string, int> colorValues = new Dictionary<string, int> {
        { "black", 0 },
        { "brown", 1 },
        { "red", 2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 }
    };
    public static string Label(string[] colors)
    {
        // calculate ohm amount
        double result = 0;
        result += colorValues[colors[0]] * 10;
        result += colorValues[colors[1]];
        int numberZeroes = colorValues[colors[2]];
        result = result * Math.Pow(10, numberZeroes);
        // add correct prefix
        if (result >= 1000000000.0 && (result % Math.Pow(10, 9) == 0))
        {
            return $"{result / Math.Pow(10, 9)} gigaohms";
        } else if (result >= 1000000.0 && (result % Math.Pow(10, 6) == 0))
        {
            return $"{result / Math.Pow(10, 6)} megaohms";
        } else if (result >= 1000.0 && (result % Math.Pow(10, 3) == 0))
        {
            return $"{result / Math.Pow(10, 3)} kiloohms";
        } else
        {
            return $"{result} ohms";
        }
    }
}
