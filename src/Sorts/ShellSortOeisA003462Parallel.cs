using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorts
{
    /// <summary>
    /// Shell sort algorithm with OEIS A003462 sequence in parallel.
    /// </summary>
    public sealed class ShellSortOeisA003462Parallel
    {
        /// <summary>
        /// Sorts array in ascending order.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, (x, y) => x.CompareTo(y));
        }

        /// <summary>
        /// Sorts array in ascending order with specified comparison method.
        /// </summary>
        /// <param name="arr">Array to sort.</param>
        /// <param name="comparison">Comparison method.</param>
        public static void Sort<T>(T[] arr, Comparison<T> comparison)
        {
            var length = arr.Length;
            for (var gap = ((int)Math.Pow(3, (int)Math.Log(length, 3)) - 1) >> 1; gap > 1; gap = (gap - 1) / 3)
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
        public static void SortDescending<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, (x, y) => y.CompareTo(x));
        }
    }
}
