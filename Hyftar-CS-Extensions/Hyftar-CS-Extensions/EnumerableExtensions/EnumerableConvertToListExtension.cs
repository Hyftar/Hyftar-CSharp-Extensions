namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Attempts to convert an <see cref="IEnumerable{T}"/> to an <see cref="IList{T}"/>, if it's not already an <see cref="IList{T}"/>, calls <see cref="Enumerable.ToList{TSource}(IEnumerable{TSource})"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable to be converted</param>
        /// <returns>The <see cref="IEnumerable{T}"/> converted to an <see cref="IList{T}"/></returns>
        public static IList<T> ConvertToList<T>(this IEnumerable<T> enumerable) => enumerable as IList<T> ?? enumerable.ToList();
    }
}
