using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sorts.Tests
{
    [TestClass]
    public class ExchangeSortTests : SortTestsBase
    {
        [TestMethod]
        public override async Task AscendingTestAsync()
        {
            var data = await GetDuplicateDataAsync();
            ExchangeSort.Sort(data);
            CollectionAssert.AreEqual(data, DataAscendingOrdered);
        }

        [TestMethod]
        public override async Task ComparisonTestAsync()
        {
            var data = await GetDuplicateDataAsync();
            ExchangeSort.Sort(data, (x, y) => x.CompareTo(y));
            CollectionAssert.AreEqual(data, DataAscendingOrdered);
        }

        [TestMethod]
        public override async Task DescendingTestAsync()
        {
            var data = await GetDuplicateDataAsync();
            ExchangeSort.SortDescending(data);
            CollectionAssert.AreEqual(data, DataDescendingOrdered);
        }
    }
}