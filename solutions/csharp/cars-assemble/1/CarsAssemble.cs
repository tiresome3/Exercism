static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if (speed == 0)
        {
            return 0.0;
        } else if (1 <= speed && speed <= 4) 
        {
            return 1.0;
        } else if (5 <= speed && speed <= 8)
        {
            return 0.9;
        } else if (speed == 9)
        {
            return 0.8;
        } else
        {
            return 0.77;
        }
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        const int optimalCarsPerHour = 221;
        double successRate = SuccessRate(speed);
        return speed * optimalCarsPerHour * successRate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        double workingItemsPerHour = ProductionRatePerHour(speed);
        return (int)(workingItemsPerHour / 60);
    }
}
