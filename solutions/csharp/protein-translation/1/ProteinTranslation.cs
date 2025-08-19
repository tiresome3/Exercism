using System.Diagnostics;

public static class ProteinTranslation
{
    private static Dictionary<string, HashSet<string>> aminoAcids = new Dictionary<string, HashSet<string>>
    {
        {"Methionine", new HashSet<string> {"AUG"} },
        {"Phenylalanine", new HashSet<string> {"UUU", "UUC"} },
        {"Leucine", new HashSet<string> {"UUA", "UUG"} },
        {"Serine", new HashSet<string> {"UCU", "UCC", "UCA", "UCG"} },
        {"Tyrosine", new HashSet<string> {"UAU", "UAC"} },
        {"Cysteine", new HashSet<string> {"UGU", "UGC"} },
        {"Tryptophan", new HashSet<string> {"UGG"} },
        {"STOP", new HashSet<string> {"UAA", "UAG", "UGA"} },
    };
    public static string[] Proteins(string strand)
    {
        var result = new List<string>();
        for (int x = 0; x < strand.Length; x += 3)
        {
            string codon = strand.Substring(x, 3);
            string protein = "";

            foreach (string prot in aminoAcids.Keys)
            {
                if (aminoAcids[prot].Contains(codon))
                {
                    protein = prot;
                }
            }
            if (protein == "STOP")
            {
                return result.ToArray();
            } else
            {
                result.Add(protein);
            }
        }
        return result.ToArray();
    }
}
