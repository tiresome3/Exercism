using System.Linq.Expressions;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (T element in collection)
        {
            if (predicate(element))
            {
                result.Add(element);
            }
        }
        return result;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (T element in collection)
        {
            if (!predicate(element))
            {
                result.Add(element);
            }
        }
        return result;
    }
}