using System.Reflection.Metadata.Ecma335;
using System.Text;

public static class House
{
    public static string[] lastLines = new string[] {
    "that belonged to the farmer sowing his corn",
    "that kept the rooster that crowed in the morn",
    "that woke the priest all shaven and shorn",
    "that married the man all tattered and torn",
    "that kissed the maiden all forlorn",
    "that milked the cow with the crumpled horn",
    "that tossed the dog",
    "that worried the cat",
    "that killed the rat",
    "that ate the malt",
    "that lay in the house that Jack built"
    };
    public static string[] firstLines = new string[] {
    "This is the house that Jack built",
    "This is the malt",
    "This is the rat",
    "This is the cat",
    "This is the dog",
    "This is the cow with the crumpled horn",
    "This is the maiden all forlorn",
    "This is the man all tattered and torn",
    "This is the priest all shaven and shorn",
    "This is the rooster that crowed in the morn",
    "This is the farmer sowing his corn",
    "This is the horse and the hound and the horn"
    };

    public static string Recite(int verseNumber)
    {
        var result = new StringBuilder();

        result.Append(firstLines[verseNumber - 1]);
        // verse 1 does not have "lastLines"
        if (verseNumber > 1)
        {
            for (int x = 10 - (verseNumber - 2); x < lastLines.Length; x++)
            {
                result.Append($" {lastLines[x]}");
            }
        }
        result.Append(".");

        return result.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var result = new StringBuilder();
        bool firstVerse = true;
        for (int x = startVerse; x <= endVerse; x++)
        {
            if (firstVerse)
            {
                result.Append(Recite(x));
                firstVerse = false;
            } else
            {
                result.Append("\n" + Recite(x));
            }
        }
        return result.ToString();
    }
}