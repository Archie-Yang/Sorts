using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorts
{
    /// <summary>
    /// Shell sort algorithm in parallel.
    /// </summary>
    public sealed class ShellSortParallel
    {
        /// <summary>
        /// Sorts array in ascending order.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="divisor">Divisor for gap calculation.</param>
        public static void Sort<T>(T[] arr, int divisor = 2) where T : IComparable<T>
        {
            Sort(arr, (x, y) => x.CompareTo(y), divisor);
        }

        /// <summary>
        /// Sorts array in ascending order with specified comparison method.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="comparison">Comparison method.</param>
        /// <param name="divisor">Divisor for gap calculation.</param>
        public static void Sort<T>(T[] arr, Comparison<T> comparison, int divisor = 2)
        {
            var length = arr.Length;
            for (var gap = length; (gap /= divisor) > 1;)
            {
                Parallel.For(0, gap, right =>
                {
                    for (; (right += gap) < length;)
                    {
                        var value = arr[right];
                        var left = right;
                        for (; left >= gap && comparison(arr[left - gap], value) > 0; arr[left] = arr[left -= gap]) ;
                        arr[left] = value;
                    }
                });
            }
            InsertionSort.Sort(arr, comparison);
        }

        /// <summary>
        /// Sorts array in descending order.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="divisor">Divisor for gap calculation.</param>
        public static void SortDescending<T>(T[] arr, int divisor = 2) where T : IComparable<T>
        {
            Sort(arr, (x, y) => y.CompareTo(x), divisor);
        }
    }
}
