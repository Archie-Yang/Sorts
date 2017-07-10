using System;
using System.Collections.Generic;

namespace Sorts
{
    /// <summary>
    /// Exchange sort algorithm.
    /// </summary>
    public sealed class ExchangeSort
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
            var margin = length - 1;
            for (var i = 0; i < margin; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (comparison(arr[i], arr[j]) > 0)
                    {
                        var tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
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
