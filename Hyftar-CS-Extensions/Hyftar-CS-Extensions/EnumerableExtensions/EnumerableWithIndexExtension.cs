namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> to an <see cref="IEnumerable{Tuple{T, int}}"/> where <see cref="Tuple{T, int}.Item2"/> is the index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns>The <see cref="IEnumerable{T}"/> converted to <see cref="Tuple{T, int}"/> where the Item2 is the index</returns>
        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T> self)
        {
            return self?.Select((item, index) => (item, index)) ?? Enumerable.Empty<(T, int)>();
        }
    }
}
