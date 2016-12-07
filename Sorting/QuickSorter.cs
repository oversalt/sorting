using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public QuickSorter(T[] array) : base(array)
        {
        }

        public override void Sort()
        {
            QuickSortRec(0, array.Length - 1);
        }

        private void QuickSortRec(int first, int last)
        {
            //base case - do nothing

            //recursive case - more than 1 element in the sub array
            if (last - first > 0)
            {
                //choose the pivot
                int pivotIndex = FindPivot(first, last);
                Swap(pivotIndex, last);
                //partition the array defined by first and last
                int partitionIndex = Partition(first - 1, last, array[last]);
                //swap the pivot into its correct position
                Swap(last, partitionIndex);
                //recursively quicksort the sub array left of the pivot (oartition index)
                QuickSortRec(first, partitionIndex - 1);
                //recursively quicksort the sub array right of the pivot (oartition index)
                QuickSortRec(partitionIndex + 1, last);
            }
        }
        /// <summary>
        /// partitions the array defined by first and last
        /// </summary>
        /// <param name="left">left starts one location left of the starting point</param>
        /// <param name="right">right starts one location right of the starting point</param>
        /// <param name="pivotValue"></param>
        /// <returns>the location where the pivot goes in the partitioned array.</returns>
        private int Partition(int left, int right, T pivotValue)
        {
            do
            {
                //at most, left will move up to the pivot location
                while (array[++left].CompareTo(pivotValue) < 0) ;
                //must check right is still to the right of left or we are done
                while (right > left && array[--right].CompareTo(pivotValue) > 0) ;
                //swap left/right
                Swap(left, right);

            } while (left < right);
            return left;
        }
        //overrideable in classes that inherit quicksorter
        protected virtual int FindPivot(int first, int last)
        {
            return last;
        }
    }
}
