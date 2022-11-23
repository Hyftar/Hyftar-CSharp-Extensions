namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Converts a single object to an <see cref="IEnumerable{T}"/> of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="single"></param>
        /// <returns>An <see cref="IEnumerable{T}"/> containing a single element of type <typeparamref name="T"/></returns>
        public static IEnumerable<T> SingleToEnumerable<T>(this T single)
        {
            yield return single;
        }
    }
}
