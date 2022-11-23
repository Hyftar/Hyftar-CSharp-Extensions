using HyftarCSExtensions.EnumerableExtensions;
using Shouldly;

namespace HyftarCSExtensionsTests
{
    [TestClass]
    public class EnumerablePivotExtensionTests
    {
        [TestMethod]
        public void ShouldPivotNestedEnumerablesCorrectly()
        {
            var elements = new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 },
                new[] { 5, 6 },
                new[] { 7, 8 },
                new[] { 9, 10 },
            };

            var pivotedElements = elements.Pivot();

            foreach (var (row, rowIndex) in pivotedElements.WithIndex())
            {
                var rowElements = row.ToArray();

                foreach (var (element, columnIndex) in rowElements.WithIndex())
                {
                    element.ShouldBe(elements[columnIndex][rowIndex]);
                }
            }
        }

        [TestMethod]
        public void ShouldYieldDifferentLengthEnumerableWhenRowsHaveDifferentElementCounts()
        {
            var elements = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5 },
                new[] { 6, 7 },
                new[] { 8, 9 },
            };

            var pivotedElements = elements.Pivot();

            pivotedElements.Take(2).ShouldAllBe(x => x.Count() == 4);
            pivotedElements.Last().Count().ShouldBe(1);
        }

        [TestMethod]
        public void ShouldPivotEmptyEnumerableCorrectly()
        {
            var elements = Enumerable.Empty<IEnumerable<int>>();

            elements.Pivot().ShouldBeEmpty();
        }
    }
}
