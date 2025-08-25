using System.Diagnostics.Metrics;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        var l1Cl2 = DoesContain(list1, list2);
        var l2Cl1 = DoesContain(list2, list1);

        if (l1Cl2 && l2Cl1)
        {
            return SublistType.Equal;
        } else if (l1Cl2 && !l2Cl1)
        {
            return SublistType.Superlist;
        } else if (!l1Cl2 && l2Cl1)
        {
            return SublistType.Sublist;
        } else
        {
            return SublistType.Unequal;
        }
    }
    private static bool DoesContain<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        bool contains = false;
        // empty lists are always contained in any other list
        if (list2.Count == 0)
        {
            return true;
        }
        for (int x = 0; x < list1.Count; x++)
        {
            if (list1[x].Equals(list2[0]) && list1.Count - x >= list2.Count)
            {
                var counter = 0;
                for (int y = 0; y < list2.Count; y++)
                {
                    if (list1[x + y].Equals(list2[y]))
                    {
                        counter++;
                    }
                }
                if (counter == list2.Count)
                {
                    contains = true;
                }
            }
        }
        return contains;
    }
}