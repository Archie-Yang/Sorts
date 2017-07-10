using System;
using System.Diagnostics;
using System.Linq;

namespace Sorts.Consoles
{
    class Program
    {
        private const int DataLength = 20000;

        private const int TestLoop = 20;

        private static readonly Stopwatch _stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            var rand = new Random();
            var originalData = new int[DataLength];
            for (var i = 0; i < originalData.Length; originalData[i++] = rand.Next()) ;
            var sortedData = originalData.OrderBy(q => q).ToArray();
            for (var i = 0; i < TestLoop; ++i)
            {
                SortTest((data) => Array.Sort(data), originalData, sortedData);
                SortTest((data) => ExchangeSort.Sort(data), originalData, sortedData);
                SortTest((data) => InsertionSort.Sort(data), originalData, sortedData);
                SortTest((data) => ShellSort.Sort(data), originalData, sortedData);
                SortTest((data) => ShellSortOeisA003462.Sort(data), originalData, sortedData);
                Console.WriteLine();
            }
        }

        private static void SortTest(Action<int[]> sortMethod, int[] originalData, int[] sortedData)
        {
            var data = new int[originalData.Length];
            Array.Copy(originalData, data, originalData.Length);
            _stopWatch.Restart();
            sortMethod(data);
            _stopWatch.Stop();
            Console.Write(data.SequenceEqual(sortedData) ? $"{_stopWatch.Elapsed}\t" : "X\t");
        }
    }
}
