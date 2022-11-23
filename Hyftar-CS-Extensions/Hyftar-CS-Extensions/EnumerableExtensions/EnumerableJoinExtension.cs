namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> into a <see cref="string"/> by using a separator in-between each element of the <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="separator">The <see cref="string"/> separator to be used between each element</param>
        /// <returns>A string representation of the <see cref="IEnumerable{T}"/></returns>
        public static string Join<T>(this IEnumerable<T> list, string separator = ", ") => string.Join(separator, list);

        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> into a <see cref="string"/> by using a separator in-between each element of the <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="separator">The <see cref="char"/> separtor to be used between each element</param>
        /// <returns>A string representation of the <see cref="IEnumerable{T}"/></returns>
        public static string Join<T>(this IEnumerable<T> list, char separator = ',') => string.Join(separator, list);
    }
}
