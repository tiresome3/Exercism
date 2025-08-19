using System.Diagnostics;
using System.Text;

public class Robot
{
    private string name;
    private static HashSet<string> robotNames = new HashSet<string>();
    private static Random rand = new Random();
    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public Robot()
    {
        this.Reset();
    }

    public void Reset()
    {
        var newName = getNewName();
        while (!robotNames.Add(newName))
        {
            newName = getNewName();
        }
        foreach(string name in robotNames)
        {
            Trace.WriteLine(name);
        }
        this.name = newName;
    }

    public string getNewName()
    {
        var result = new StringBuilder();
        result.Append((char)(rand.Next(26) + 'A'));
        result.Append((char)(rand.Next(26) + 'A'));
        result.Append(rand.Next(10));
        result.Append(rand.Next(10));
        result.Append(rand.Next(10));
        return result.ToString();
    }
}