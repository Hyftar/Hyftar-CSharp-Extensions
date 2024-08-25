namespace HyftarCSExtensions.EnumerableExtensions;

public static class EnumerableTupleSelectExtension
{
    public static IEnumerable<TResult> Select<TItem1, TItem2, TResult>(this IEnumerable<(TItem1, TItem2)> source, Func<TItem1, TItem2, TResult> selector)
    {
        return source.Select(s => selector(s.Item1, s.Item2));
    }

    public static IEnumerable<TResult> Select<TItem1, TItem2, TItem3, TResult>(this IEnumerable<(TItem1, TItem2, TItem3)> source, Func<TItem1, TItem2, TResult> selector)
    {
        return source.Select(s => selector(s.Item1, s.Item2));
    }

    public static IEnumerable<TResult> Select<TItem1, TItem2, TItem3, TITem4, TResult>(this IEnumerable<(TItem1, TItem2, TItem3, TITem4)> source, Func<TItem1, TItem2, TResult> selector)
    {
        return source.Select(s => selector(s.Item1, s.Item2));
    }
}
