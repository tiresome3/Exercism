using System.Reflection.Metadata.Ecma335;

public class HighScores
{
    private List<int> scores;
    public HighScores(List<int> list) => this.scores = list;

    public List<int> Scores() => this.scores;

    public int Latest() => scores[scores.Count() - 1];

    public int PersonalBest() => scores.Max();

    public List<int> PersonalTopThree()
    {
        var result = this.scores.ToList();
        result.Sort();
        result.Reverse();
        return result.Count() > 3 ? result.GetRange(0, 3) : result;
    }
}