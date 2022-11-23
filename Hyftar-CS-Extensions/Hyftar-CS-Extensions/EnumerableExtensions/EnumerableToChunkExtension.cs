namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Splits an <see cref="IEnumerable{T}"/> into chunks of size <paramref name="chunkSize"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="chunkSize">Size of the chunks</param>
        /// <returns>The <see cref="IEnumerable{T}"/> split into chunks of size <paramref name="chunkSize"/></returns>
        public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> enumerable, int chunkSize)
        {
            if (chunkSize < 1)
            {
                throw new ArgumentOutOfRangeException("Chunk size must be greater than or equal to one");
            }

            var itemsReturned = 0;
            var list = enumerable.ToList();
            var count = list.Count;

            while (itemsReturned < count)
            {
                var currentChunkSize = Math.Min(chunkSize, count - itemsReturned);

                yield return list.GetRange(itemsReturned, currentChunkSize);

                itemsReturned += currentChunkSize;
            }
        }
    }
}
