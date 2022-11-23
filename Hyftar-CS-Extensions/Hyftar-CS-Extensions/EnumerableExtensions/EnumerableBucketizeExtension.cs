namespace HyftarCSExtensions.EnumerableExtensions
{
    public static partial class EnumerableExtensionMethods
    {
        /// <summary>
        /// Transforms an <see cref="IEnumerable{T}"/> into buckets by applying the current rule until it no longer returns true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable to be bucketized</param>
        /// <param name="bucketsRules">Rule of each bucket to split the enumerable. The bucketizer changes bucket when the current rule returns false.</param>
        /// <returns>A bucketized array of size <paramref name="bucketsRules"/></returns>
        public static IEnumerable<T>[] BucketizeWithRules<T>(this IEnumerable<T> enumerable, Func<T, bool>[] bucketsRules)
        {
            var enumerator = enumerable.GetEnumerator();

            var currentBucketIndex = 0;

            var buckets =
                Enumerable.Range(0, bucketsRules.Length + 1)
                          .Select(_ => new List<T>())
                          .ToArray();

            var currentBucket = buckets.ElementAt(0);
            var currentRule = bucketsRules.ElementAt(0);

            var shouldBreak = false;
            while (enumerator.MoveNext() && currentBucketIndex < bucketsRules.Length)
            {
                if (!currentRule(enumerator.Current))
                {
                    do
                    {
                        currentBucketIndex++;

                        if (currentBucketIndex >= bucketsRules.Length)
                        {
                            currentBucket = buckets.Last();
                            shouldBreak = true;
                            break;
                        }

                        currentBucket = buckets.ElementAt(currentBucketIndex);
                        currentRule = bucketsRules.ElementAt(currentBucketIndex);
                    } while (!currentRule(enumerator.Current));
                }

                currentBucket.Add(enumerator.Current);

                if (shouldBreak)
                {
                    break;
                }
            }

            while (enumerator.MoveNext())
            {
                currentBucket.Add(enumerator.Current);
            }

            return buckets;
        }
    }
}
