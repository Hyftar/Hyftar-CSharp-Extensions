using HyftarCSExtensions.EnumerableExtensions;
using Shouldly;

namespace HyftarCSExtensionsTests
{
    [TestClass]
    public class BucketizerTests
    {
        [TestMethod]
        public void ShouldBucketizeInto3BucketsWhenTwoRulesAreSpecified()
        {
            var array = new[] { 0, 1, 0, 2, 0 };

            var buckets =
                array.BucketizeWithRules(
                    new Func<int, bool>[]
                    {
                        (element) => element is 0 or 1,
                        (element) => element is 0 or 2,
                    }
                );

            buckets.Length.ShouldBe(3);

            buckets[0].Count().ShouldBe(3);
            buckets[1].Count().ShouldBe(2);
            buckets[2].ShouldBeEmpty();
        }

        [TestMethod]
        public void ShouldBucketizeIntoLastBucketWhenNoRuleMatch()
        {
            var array = new[] { 3, 3, 3, 3, 3 };

            var buckets =
                array.BucketizeWithRules(
                    new Func<int, bool>[]
                    {
                        (element) => element is 0 or 1,
                        (element) => element is 0 or 2,
                    }
                );

            buckets.Length.ShouldBe(3);

            buckets[0].ShouldBeEmpty();
            buckets[1].ShouldBeEmpty();
            buckets[2].Count().ShouldBe(5);
        }

        [TestMethod]
        public void ShouldBucketizeEveryElementWhenRulesAreAppliedCorrectly()
        {
            var array =
                new[]
                { 
                    // Bucket 1
                    1,
                    0,
                    
                    // Bucket 2
                    2,
                    0,
                    
                    // Bucket 3
                    4,
                    0,
                    
                    // Bucket 4
                    3,
                    0,
                    3,

                    // Bucket 5
                    1,
                    2,
                    3,
                    4,
                    0,
                };

            var buckets =
                array.BucketizeWithRules(
                    new Func<int, bool>[]
                    {
                        (element) => element is 0 or 1,
                        (element) => element is 0 or 2,
                        (element) => element is 0 or 4,
                        (element) => element is 0 or 3,
                    }
                );

            buckets.Length.ShouldBe(5);

            buckets[0].Count().ShouldBe(2);
            buckets[1].Count().ShouldBe(2);
            buckets[2].Count().ShouldBe(2);
            buckets[3].Count().ShouldBe(3);

            buckets[4].Count().ShouldBe(5);
        }
    }
}
