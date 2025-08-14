using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text.RegularExpressions;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        Regex pattern = new Regex(@"(?<month>\d{1,2})\/(?<day>\d{1,2})\/(?<year>\d{4}) (?<hour>\d{2}):(?<minute>\d{2}):(?<second>\d{2})");
        Match match = pattern.Match(appointmentDateDescription);
        int year = int.Parse(match.Groups["year"].Value);
        int hour = int.Parse(match.Groups["hour"].Value);
        int minute = int.Parse(match.Groups["minute"].Value);
        int second = int.Parse(match.Groups["second"].Value);
        int day = int.Parse(match.Groups["day"].Value);
        int month = int.Parse(match.Groups["month"].Value);

        var localDateTime = new DateTime(year, month, day, hour, minute, second);

      return TimeZoneInfo.ConvertTimeToUtc(localDateTime, TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneID(location)));
    }
    private static String GetTimeZoneID(Location location)
    {
        string osName = RuntimeInformation.OSDescription;
        string timeZoneID = "";
        if ((osName.Contains("Linux") || osName.Contains("OSX")) && location is Location.NewYork)
        {
            timeZoneID = "America/New_York";
        } else if ((osName.Contains("Linux") || osName.Contains("OSX")) && location is Location.London)
        {
            timeZoneID = "Europe/London";
        } else if ((osName.Contains("Linux") || osName.Contains("OSX")) && location is Location.Paris)
        { 
            timeZoneID = "Europe/Paris";
        } else if (osName.Contains("Windows") && location is Location.NewYork)
        {
            timeZoneID = "Eastern Standard Time";
        } else if (osName.Contains("Windows") && location is Location.London)
        { 
            timeZoneID = "GMT Standard Time";
        } else if (osName.Contains("Windows") && location is Location.Paris)
        { 
            timeZoneID = "W. Europe Standard Time";
        }

        return timeZoneID;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddMinutes(-105);
            default:
                return appointment.AddMinutes(-30);
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo locTZI = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneID(location));
        bool isDSTAppointment = locTZI.IsDaylightSavingTime(dt);
        bool isDST7DaysBefore = locTZI.IsDaylightSavingTime(dt.AddDays(-7));
        return isDST7DaysBefore != isDSTAppointment;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        switch (location)
        {
            case Location.NewYork:
                if (DateTime.TryParse(dtStr, new CultureInfo("en-US"), out var dtUS))
                {
                    return dtUS;
                } else
                {
                    return new DateTime(1, 1, 1, 0, 0, 0);
                }
            case Location.London:
                if (DateTime.TryParse(dtStr, new CultureInfo("en-GB"), out var dtGB))
                {
                    return dtGB;
                } else
                {
                    return new DateTime(1, 1, 1, 0, 0, 0);
                }
            default:
                if (DateTime.TryParse(dtStr, new CultureInfo("fr-FR"), out var dtFR))
                {
                    return dtFR;
                } else
                {
                    return new DateTime(1, 1, 1, 0, 0, 0);
                }
        }
    }
}
