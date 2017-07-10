using System;
using System.Collections.Generic;

namespace Sorts
{
    /// <summary>
    /// Insertion sort algorithm.
    /// </summary>
    public sealed class InsertionSort
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
            for (var right = 1; right < length; right++)
            {
                var value = arr[right];
                var left = right;
                for (; left > 0 && comparison(arr[left - 1], value) > 0; arr[left] = arr[--left]) ;
                arr[left] = value;
            }
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
