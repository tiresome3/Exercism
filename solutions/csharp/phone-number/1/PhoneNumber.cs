using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        Regex pattern = new Regex(@"^(1|\+1)?[\(, ,\),\-,\.]*(?<block1>[2-9][0-9]{2})[\(, ,\),\-,\.]*(?<block2>[2-9][0-9]{2})[\(, ,\),\-,\.]*(?<block3>[0-9]{4})[\(,\s,\),\-,\.]*$");
        if (!pattern.IsMatch(phoneNumber))
        {
            throw new ArgumentException();
        } else
        {
            var match = pattern.Match(phoneNumber);
            return match.Groups["block1"].Value + match.Groups["block2"].Value + match.Groups["block3"].Value;
        }
    }
}