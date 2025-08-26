using System.Text;

public static class OcrNumbers
{
    private static Dictionary<string, string> numbers = new Dictionary<string, string>
    {
        {" _ " + "| |" + "|_|" + "   ", "0"},
        {"   " + "  |" + "  |" + "   ", "1"},
        {" _ " + " _|" + "|_ " + "   ", "2"},
        {" _ " + " _|" + " _|" + "   ", "3"},
        {"   " + "|_|" + "  |" + "   ", "4"},
        {" _ " + "|_ " + " _|" + "   ", "5"},
        {" _ " + "|_ " + "|_|" + "   ", "6"},
        {" _ " + "  |" + "  |" + "   ", "7"},
        {" _ " + "|_|" + "|_|" + "   ", "8"},
        {" _ " + "|_|" + " _|" + "   ", "9"}
    };
    public static string Convert(string input)
    {
        var inputArray = input.Split("\n");
        var numberRows = inputArray.Length;
        int lineLength = inputArray[0].Length;
        // rows are multiples of four or lines are multiples of three
        if (numberRows % 4 != 0 || lineLength % 3 != 0)
        {
            throw new ArgumentException(); 
        } else
        {
            var result = new StringBuilder();
            // split input into rows
            for (int x = 0; x < numberRows; x += 4)
            {
                var subarray = new string[4];
                Array.Copy(inputArray, x, subarray, 0, 4);
                result.Append(SingleRow(subarray) + ",");
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
    private static string SingleRow(string[] inputArray)
    {
        var result = new StringBuilder();
        int lineLength = inputArray[0].Length;
        int amountNumbers = lineLength / 3;
        // split rows into digits
        for (int x = 0; x < lineLength; x += 3)
        {
            var singleNumber = new StringBuilder();
            singleNumber.Append(inputArray[0].Substring(x, 3));
            singleNumber.Append(inputArray[1].Substring(x, 3));
            singleNumber.Append(inputArray[2].Substring(x, 3) + "   ");
            result.Append(SingleNumber(singleNumber.ToString()));
        }
        return result.ToString();
    }
    private static string SingleNumber(string input)
    {
        if (numbers.Keys.Contains(input))
        {
            return numbers[input];
        } else
        {
            return "?";
        }
    }
}