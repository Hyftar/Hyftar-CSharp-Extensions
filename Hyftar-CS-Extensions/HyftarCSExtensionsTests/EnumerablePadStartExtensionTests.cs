using HyftarCSExtensions.EnumerableExtensions;
using Shouldly;

namespace HyftarCSExtensionsTests
{
    [TestClass]
    public class EnumerablePadStartExtensionTests
    {
        [TestMethod]
        public void ShouldAddItemsWhenEmptyEnumerable()
        {
            var items = Enumerable.Empty<int>();

            var paddedItems = items.PadStart(2).ToList();

            paddedItems.Count.ShouldBe(2);
            paddedItems.First().ShouldBe(0);
            paddedItems.Last().ShouldBe(0);
        }

        [TestMethod]
        public void ShouldAddItemsWhenNonEmptyEnumerable()
        {
            var items = new[] { 1, 2, 3 };

            var paddedItems = items.PadStart(5).ToList();

            paddedItems.Count.ShouldBe(5);

            paddedItems[0].ShouldBe(0);
            paddedItems[1].ShouldBe(0);

            paddedItems[2].ShouldBe(1);
            paddedItems[3].ShouldBe(2);
            paddedItems[4].ShouldBe(3);
        }

        [TestMethod]
        public void ShouldNotAddItemsWhenEnumerableIsBiggerThanTotalLength()
        {
            var items = new[] { 1, 2, 3, 4, 5 };

            var paddedItems = items.PadStart(3).ToList();

            paddedItems.Count.ShouldBe(5);

            paddedItems[0].ShouldBe(1);
            paddedItems[1].ShouldBe(2);
            paddedItems[2].ShouldBe(3);
            paddedItems[3].ShouldBe(4);
            paddedItems[4].ShouldBe(5);
        }

        [TestMethod]
        public void ShouldAddValueDifferentThanDefaultWhenEnumerableIsSmallerThanTotalLength()
        {
            var items = new[] { 1 };

            var paddedItems = items.PadStart(3, 255).ToList();

            paddedItems.Count.ShouldBe(3);

            paddedItems[0].ShouldBe(255);
            paddedItems[1].ShouldBe(255);

            paddedItems[2].ShouldBe(1);
        }
    }
}