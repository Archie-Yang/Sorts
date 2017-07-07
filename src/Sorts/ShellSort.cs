using System;
using System.Collections.Generic;

namespace Sorts
{
    /// <summary>
    /// Shell sort algorithm.
    /// </summary>
    public sealed class ShellSort
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
            for (int length = arr.Length, gap = length / divisor; ; gap /= divisor)
            {
                if (gap == 0)
                {
                    gap = 1;
                }
                for (var target = gap; target < length; ++target)
                {
                    var value = arr[target];
                    var offset = target;
                    var previous = target - gap;
                    for (; previous >= 0 && comparison(arr[previous], value) > 0;)
                    {
                        arr[offset] = arr[previous];
                        offset -= gap;
                        previous -= gap;
                    }
                    if (target != offset)
                    {
                        arr[offset] = value;
                    }
                }
                if (gap == 1)
                {
                    break;
                }
            }
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
