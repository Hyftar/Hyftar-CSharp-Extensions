using HyftarCSExtensions.EnumerableExtensions;
using Shouldly;

namespace HyftarCSExtensionsTests
{
    [TestClass]
    public class EnumerableShuffleExtensionTests
    {
        private const int RANDOM_SEED = 0xC0FFEE;

        [TestMethod]
        public void ShouldShuffleArrayCorrectlyWithSeed()
        {
            var elements = new[] { 1, 2, 3, 4, 5 };

            var shuffledElements = elements.Shuffle(RANDOM_SEED).ToArray();

            shuffledElements.Length.ShouldBe(elements.Length);

            shuffledElements[0].ShouldBe(4);
            shuffledElements[1].ShouldBe(3);
            shuffledElements[2].ShouldBe(2);
            shuffledElements[3].ShouldBe(5);
            shuffledElements[4].ShouldBe(1);
        }

        [TestMethod]
        public void ShouldShuffleArrayCorrectlyWhenOneElement()
        {
            var elements = new[] { 1 };

            var shuffledElements = elements.Shuffle(RANDOM_SEED).ToArray();

            shuffledElements.Length.ShouldBe(elements.Length);

            shuffledElements[0].ShouldBe(1);
        }

        [TestMethod]
        public void ShouldShuffleArrayCorrectlyWhenEmpty()
        {
            var elements = Enumerable.Empty<int>();

            var shuffledElements = elements.Shuffle(RANDOM_SEED).ToArray();

            shuffledElements.ShouldBeEmpty();
        }
    }
}
