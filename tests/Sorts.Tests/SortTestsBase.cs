using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sorts.Tests
{
    [TestClass]
    public abstract class SortTestsBase
    {
        protected const int DataLength = 100;

        protected int[] Data;

        protected int[] DataAscendingOrdered;

        protected int[] DataDescendingOrdered;

        [TestInitialize]
        public async Task InitializeAsync()
        {
            var rand = new Random();
            Data = new int[DataLength];
            for (var i = 0; i < Data.Length; Data[i++] = rand.Next()) ;
            await Task.WhenAll(
                Task.Run(() => DataAscendingOrdered = Data.OrderBy(q => q).ToArray()),
                Task.Run(() => DataDescendingOrdered = Data.OrderByDescending(q => q).ToArray()));
        }

        public abstract Task AscendingTestAsync();

        public abstract Task ComparisonTestAsync();

        public abstract Task DescendingTestAsync();

        protected Task<int[]> GetDuplicateDataAsync()
        {
            return Task.Run(() =>
            {
                var data = new int[Data.Length];
                Array.Copy(Data, data, Data.Length);
                return data;
            });
        }
    }
}
