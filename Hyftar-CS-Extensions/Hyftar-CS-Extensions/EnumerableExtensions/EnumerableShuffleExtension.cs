namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Shuffles the order of the elements of an <see cref="IEnumerable{T}"/> using the Fisher–Yates shuffle
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to be shuffled</param>
        /// <returns>A shuffled version of the original <paramref name="enumerable"/></returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, int randomSeed)
        {
            var elements = enumerable.ToArray();

            var randomProvider = new Random(randomSeed);
            var n = elements.Length;
            
            while (n-- > 0)
            {
                var k = randomProvider.Next(n + 1);
                
                (elements[n], elements[k]) = (elements[k], elements[n]);

                yield return elements[n];
            }
        }
    }
}
