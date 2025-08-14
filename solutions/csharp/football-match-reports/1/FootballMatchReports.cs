public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3: case 4:
                return "center back";
            case 5:
                return "right back";
            case 6: case 7: case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";
                
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case string:
                return (string)report;
            case int:
                return $"There are {report} supporters at the match.";
            case Foul foul:
                return foul.GetDescription();
            case Injury  inj:
                return "Oh no! " + inj.GetDescription() + " Medics are on the field.";
            case Incident inc:
                return inc.GetDescription();
            case Manager man when man.Club == null:
                return man.Name;
            case Manager man:
                return $"{man.Name} ({man.Club})";
            default:
                return "";
        }
    }
}
