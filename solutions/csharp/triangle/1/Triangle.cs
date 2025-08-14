public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        return side1 != side2 && side2 != side3 && side3 != side1 && IsTriangle(side1, side2, side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        var numberSameSized = 0;
        if (side1 == side2)
        {
            numberSameSized++;
        } else if (side2 == side3)
        {
            numberSameSized++;
        } else if (side3 == side1)
        {
            numberSameSized++;
        }
        if (numberSameSized >= 1 && IsTriangle(side1, side2, side3)) 
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        return side1 == side2 && side2 == side3 && side3 == side1 && IsTriangle(side1, side2, side3);
    }
    private static bool IsTriangle(double side1, double side2, double side3)
    {
        return side1 + side2 >= side3 && side2 + side3 >= side1 && side1 + side3 >= side2 && side1 > 0 && side2 > 0 && side3 > 0;
    }
}