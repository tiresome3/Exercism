public class GradeSchool
{
    private SortedDictionary<int, List<string>> roster = new SortedDictionary<int, List<string>>();
    public bool Add(string student, int grade)
    {
        bool studentInRoster = false;
        foreach (List<string> gra in roster.Values)
        {
            if (gra.Contains(student)) studentInRoster = true;
        }
        if (studentInRoster) return false;
        if (!roster.ContainsKey(grade))
        {
            roster.Add(grade, new List<string> { student });
            return true;
        } else
        {
            if (roster[grade].Contains(student))
            {
                return false;
            }
            roster[grade].Add(student);
            return true;
        }
    }

    public IEnumerable<string> Roster()
    {
        var result = new List<string>();
        foreach (List<string> grade in roster.Values)
        {
            var tmpGrade = new List<string>(grade);
            tmpGrade.Sort();
            result.AddRange(tmpGrade);
        }
        return result;
    }

    public IEnumerable<string> Grade(int grade)
    {
        if (!roster.ContainsKey(grade))
        {
            return new List<string>();
        } else
        {
            var tmpGrade = new List<string>(roster[grade]);
            tmpGrade.Sort();
            return tmpGrade;
        }
    }
}