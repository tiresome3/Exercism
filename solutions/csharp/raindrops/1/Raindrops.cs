using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        StringBuilder result = new StringBuilder();
        bool any = false;

        if (number % 3 == 0)
        {
            result.Append("Pling");
            any = true;
        }
        if (number % 5 == 0)
        {
            result.Append("Plang");
            any = true;
        }
        if (number % 7 == 0)
        {
            result.Append("Plong");
            any = true;
        } 
        if (!any) 
        {
            return number.ToString();
        }

        return result.ToString();
    }
}