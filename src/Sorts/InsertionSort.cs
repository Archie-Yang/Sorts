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
            T value;
            int length = arr.Length, target = 0, offset, previous;
            for (; ++target < length;)
            {
                value = arr[target];
                for (offset = previous = target; offset > 0 && comparison(arr[--previous], value) > 0; arr[offset--] = arr[previous]) ;
                if (target != offset)
                {
                    arr[offset] = value;
                }
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
