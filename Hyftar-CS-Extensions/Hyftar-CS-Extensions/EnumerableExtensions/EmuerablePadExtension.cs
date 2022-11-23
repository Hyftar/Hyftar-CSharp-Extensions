namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Adds <paramref name="padValue"/> elements to the end of the <see cref="IEnumerable{T}"/> until it is at least <paramref name="totalLength"/> elements long
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="totalLength">Minimum length of the resulting <see cref="IEnumerable{T}"/></param>
        /// <param name="padValue">The value for value for padding elements</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that is at least <paramref name="totalLength"/> elements long</returns>
        public static IEnumerable<T?> PadEnd<T>(this IEnumerable<T> enumerable, int totalLength, T? padValue = default)
        {
            var currentItemCount = 0;

            foreach (var item in enumerable)
            {
                yield return item;

                currentItemCount++;
            }

            while (currentItemCount++ < totalLength)
            {
                yield return padValue;
            }
        }

        /// <summary>
        /// Adds <paramref name="padValue"/> elements to the start of the <paramref name="enumerable"/> until it is at least <paramref name="totalLength"/> elements long
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="totalLength">Minimum length of the resulting <see cref="IEnumerable{T}"/></param>
        /// <param name="padValue">The value for value for padding elements</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that is at least <paramref name="totalLength"/> elements long</returns>
        public static IEnumerable<T?> PadStart<T>(this IEnumerable<T> enumerable, int totalLength, T? padValue = default)
        {
            var list = enumerable.ConvertToList();

            var padLength = totalLength - list.Count;

            var currentItemCount = 0;

            while (currentItemCount++ < padLength)
            {
                yield return padValue;

            }

            foreach (var item in enumerable)
            {
                yield return item;
            }
        }
    }
}
