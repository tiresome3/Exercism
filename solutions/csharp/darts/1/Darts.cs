using System.Diagnostics;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double radiusOfPoint = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        Trace.WriteLine(radiusOfPoint);
        if (radiusOfPoint <= 1)
        {
            return 10;
        } else if (radiusOfPoint <= 5)
        {
            return 5;
        } else if (radiusOfPoint <= 10)
        {
            return 1;
        } else
        {
            return 0;
        }
    }
}
