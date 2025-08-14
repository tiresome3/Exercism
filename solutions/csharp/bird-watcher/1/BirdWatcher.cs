using System.Runtime.CompilerServices;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return this.birdsPerDay.Last();
    }

    public void IncrementTodaysCount()
    {
        this.birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        if (this.birdsPerDay.Contains(0))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for (int x = 0; x < numberOfDays; x++)
        {
            count += birdsPerDay[x];
        }
        return count;
    }

    public int BusyDays()
    {
        int count = 0;
        foreach (int numberOfBirds in birdsPerDay)
        {
            if (numberOfBirds >= 5)
            {
                count++;
            }
        }
        return count;
    }
}
