using System.Linq.Expressions;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        checked
        {
            try
            {
                var result = @base * multiplier;
                return result.ToString();
            } catch (OverflowException exep)
            {
                return "*** Too Big ***";
            }
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var result = @base * multiplier;
        if (float.IsInfinity(result))
        {
            return "*** Too Big ***";
        } else 
        { 
        return result.ToString();
        }
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        checked
        {
            try
            {
                var result = salaryBase * multiplier;
                return result.ToString();
            } catch (OverflowException exep)
            {
                return "*** Much Too Big ***";
            }
        }
    }
}
