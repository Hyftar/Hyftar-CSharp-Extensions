namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Converts the rows of an <see cref="IEnumerable{IEnumerable{T}}"/> into columns
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns>The <see cref="IEnumerable{IEnumerable{T}}"/> pivoted on itself</returns>
        public static IEnumerable<IEnumerable<T>> Pivot<T>(this IEnumerable<IEnumerable<T>> enumerable)
        {
            return
                enumerable
                    .SelectMany(inner => inner.WithIndex())
                    .GroupBy(x => x.Index, x => x.Item)
                    .Select(g => g.ToList());
        }
    }
}
