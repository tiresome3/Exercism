using System.Text;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length < 1 || sliceLength < 1 || sliceLength > numbers.Length)
        {
            throw new ArgumentException();
        }
        var result = new List<string> { };

        for (int x = 0; x < numbers.Length; x++)
        {
            if (x + sliceLength - 1 < numbers.Length)
            {
                var subString = new StringBuilder() { };
                for (int y = x; y < x + sliceLength; y++)
                {
                    subString.Append(numbers[y]);
                }
                result.Add(subString.ToString());
            }
        }

        return result.ToArray();
    }
}