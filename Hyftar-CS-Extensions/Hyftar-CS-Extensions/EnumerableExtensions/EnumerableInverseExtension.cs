namespace HyftarCSExtensions.EnumerableExtensions;

public static class EnumerableInverseExtension
{
    public static bool None<T>(this IEnumerable<T> source) => !source.Any();

    public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate) => !source.Any(predicate);

    /// <summary>
    /// Returns an <see cref="IEnumerable{T}"/> without the elements where the <paramref name="predicate"/> returned true
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <returns>Enumerable without the elements where the predicate returned true</returns>
    public static IEnumerable<T> Reject<T>(this IEnumerable<T> source, Func<T, bool> predicate) => source.Where(x => !predicate(x));
}
