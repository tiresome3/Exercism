public class SpaceAge
{
    private double ageInEarthSeconds;
    private double earthYearInSeconds;
    public SpaceAge(int seconds)
    {
        this.ageInEarthSeconds = seconds;
        this.earthYearInSeconds = 31557600;
    }

    public double OnEarth()
    {
        return (this.ageInEarthSeconds / this.earthYearInSeconds);
    }

    public double OnMercury()
    {
        double orbitalPeriodInEarthYears = 0.2408467;
        double orbitalPeriodInEarthSeconds = orbitalPeriodInEarthYears * this.earthYearInSeconds;
        return this.ageInEarthSeconds / orbitalPeriodInEarthSeconds;
    }

    public double OnVenus()
    {
        double orbitalPeriodInEarthYears = 0.61519726;
        return this.ageInEarthSeconds / (orbitalPeriodInEarthYears * this.earthYearInSeconds);
    }

    public double OnMars()
    {
        double orbitalPeriodInEarthYears = 1.8808158;
        return this.ageInEarthSeconds / (orbitalPeriodInEarthYears * this.earthYearInSeconds);
    }

    public double OnJupiter()
    {
        double orbitalPeriodInEarthYears = 11.862615;
        return this.ageInEarthSeconds / (orbitalPeriodInEarthYears * this.earthYearInSeconds);
    }

    public double OnSaturn()
    {
        double orbitalPeriodInEarthYears = 29.447498;
        return this.ageInEarthSeconds / (orbitalPeriodInEarthYears * this.earthYearInSeconds);
    }

    public double OnUranus()
    {
        double orbitalPeriodInEarthYears = 84.016846;
        return this.ageInEarthSeconds / (orbitalPeriodInEarthYears * this.earthYearInSeconds);
    }

    public double OnNeptune()
    {
        double orbitalPeriodInEarthYears = 164.79132;
        return this.ageInEarthSeconds / (orbitalPeriodInEarthYears * this.earthYearInSeconds);
    }
}