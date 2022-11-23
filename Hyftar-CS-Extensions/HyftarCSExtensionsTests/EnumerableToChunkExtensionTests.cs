using HyftarCSExtensions.EnumerableExtensions;
using Shouldly;

namespace HyftarCSExtensionsTests
{
    [TestClass]
    public class EnumerableToChunkExtensionTests
    {
        [TestMethod]
        public void ShouldSplitIntoThreeChunksWhenNineElementsAndChunksOfSizeThree()
        {
            var elements = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var chunks = elements.ToChunks(3).ToArray();

            chunks.Length.ShouldBe(3);
            
            var firstChunk = chunks[0].ToArray();
            firstChunk[0].ShouldBe(1);
            firstChunk[1].ShouldBe(2);
            firstChunk[2].ShouldBe(3);

            var secondChunk = chunks[1].ToArray();
            secondChunk[0].ShouldBe(4);
            secondChunk[1].ShouldBe(5);
            secondChunk[2].ShouldBe(6);

            var thirdChunk = chunks[2].ToArray();
            thirdChunk[0].ShouldBe(7);
            thirdChunk[1].ShouldBe(8);
            thirdChunk[2].ShouldBe(9);
        }

        [TestMethod]
        public void ShouldSplitIntoOneChunkWhenChunkSizeIsBiggerThanElementsCount()
        {
            var elements = new[] { 1, 2, 3 };

            var chunks = elements.ToChunks(9).ToArray();

            chunks.Length.ShouldBe(1);

            var firstChunk = chunks[0].ToArray();
            firstChunk[0].ShouldBe(1);
            firstChunk[1].ShouldBe(2);
            firstChunk[2].ShouldBe(3);
        }

        [TestMethod]
        public void ShouldSplitIntoNoChunkWhenEnumerableIsEmpty()
        {
            var elements = Enumerable.Empty<int>();

            var chunks = elements.ToChunks(9).ToArray();

            chunks.ShouldBeEmpty();
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenSplittingIntoChunksOfSizeZero()
        {
            var elements = Enumerable.Empty<int>();

            Should.Throw<ArgumentOutOfRangeException>(() => elements.ToChunks(0).ToArray());
        }
    }
}
