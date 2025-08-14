using System.Diagnostics;
using System.Text.RegularExpressions;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        string[] monthNames = new string[] { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string test = appointmentDateDescription;

        foreach (string monthName in monthNames)
        {
            if (appointmentDateDescription.Contains(monthName))
            {
                test = appointmentDateDescription.Replace(monthName, (Array.IndexOf(monthNames, monthName)+ 1).ToString());
            }
        }

        Regex pattern = new Regex(@"(?<month>\d{1,2})\/(?<day>\d{1,2})\/(?<year>\d{4}) (?<hour>\d{2}):(?<minute>\d{2}):(?<second>\d{2})|(?<month>\d{1,2}) (?<day>\d{1,2})\, (?<year>\d{4}) (?<hour>\d{2}):(?<minute>\d{2}):(?<second>\d{2})");
        Match match = pattern.Match(test);
        int year = int.Parse(match.Groups["year"].Value);
        int hour = int.Parse(match.Groups["hour"].Value);
        int minute = int.Parse(match.Groups["minute"].Value);
        int second = int.Parse(match.Groups["second"].Value);
        int day = int.Parse(match.Groups["day"].Value);
        int month = int.Parse(match.Groups["month"].Value);

        return new DateTime(year, month, day, hour, minute, second);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        if (appointmentDate < DateTime.Now)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        if (appointmentDate.TimeOfDay >= new TimeSpan(12, 0, 0) && appointmentDate.TimeOfDay < new TimeSpan(18, 0, 0))
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}.";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year , 9, 15, 0, 0, 0);
    }
}
