using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Text;

using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

using Xunit.Sdk;

public class Anagram
{
    string baseWord;
    public Anagram(string baseWord)
    {
        this.baseWord = baseWord.ToLower();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var result = new List<string>();

        foreach (string word in potentialMatches)
        {
            var isAnagram = true;
            var baseWordCP = this.baseWord;
            // test if potential match is the same as base word
            if (word.ToLower() != baseWordCP)
            {
                foreach (char letter in word)
                {
                    if (!baseWordCP.Contains(char.ToLower(letter)))
                    {
                        isAnagram = false;
                    }
                    else
                    {
                        int ind = baseWordCP.IndexOf(char.ToLower(letter));
                        baseWordCP = baseWordCP.Remove(ind, 1);
                    }
                } 
            } else
            {
                isAnagram = false;
            }
            // test for subset
            if (isAnagram && baseWordCP == "")
            {
                result.Add(word);
            }
        }
        return result.ToArray();
    }
}