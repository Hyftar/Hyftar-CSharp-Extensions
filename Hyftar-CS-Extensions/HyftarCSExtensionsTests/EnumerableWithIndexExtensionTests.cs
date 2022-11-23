using HyftarCSExtensions.EnumerableExtensions;
using Shouldly;

namespace HyftarCSExtensionsTests
{
    [TestClass]
    public class EnumerableWithIndexExtensionTests
    {
        [TestMethod]
        public void ShouldAddCorrectIndexToEachElement()
        {
            var elements = new[] { 7, 8, 9, 4, 5, 6, 1, 2, 3 };

            var currentIndex = 0;
            foreach (var (element, index) in elements.WithIndex())
            {
                index.ShouldBe(currentIndex++);
            }
        }

        [TestMethod]
        public void ShouldNotAddElementsToEmptyEnumerable()
        {
            var elements = Enumerable.Empty<int>();

            var indexedElements = elements.WithIndex();

            indexedElements.ShouldBeEmpty();
        }
    }
}
