using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class HeapSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public HeapSorter(T[] array) : base(array) { }

        public override void Sort()
        {
            //Heapify the original tree
            Heapify();
            //For each largest element
            //Remove max and trickle down top element
            for (int i = array.Length - 1; i > 0; i--)
            {
                RemoveNextMax(i);
            }
        }

        private void RemoveNextMax(int lastPos)
        {
            //Get reference to the largest element in the array
            T max = array[0];

            //Put last element in unsorted part of the array into the first position
            array[0] = array[lastPos];
            TrickleDown(0, lastPos - 1);
            array[lastPos] = max;
        }

        /// <summary>
        /// Turn the entire array into a max-heap
        /// </summary>
        private void Heapify()
        {
            //Get the first parent at the bottom of tree
            int parentIndex = GetParentIndex(array.Length-1);

            //loop back through the parents and adjust elements as necessary
            for (int index = parentIndex; index >= 0; index--)
            {
                TrickleDown(index, array.Length - 1);
            }
        }

        /// <summary>
        /// Looks at a single parent node in the tree and swaps it with the larger of its two children
        /// assuming that the child is larger than the parent
        /// </summary>
        /// <param name="index">Location of node to trickle down</param>
        /// <param name="lastPost">End of the unsorted part of the entire array</param>
        private void TrickleDown(int index, int lastPos)
        {
            T current = array[index];
            int largerChildIndex = GetLeftChildIndex(index);
            bool done = false;

            //Keep going while there is a child and the child is larger
            while(!done && largerChildIndex <= lastPos)
            {
                int rightChildIndex = GetRightChildIndex(index);
                //Check which child is larger
                if(rightChildIndex <= lastPos && array[rightChildIndex].CompareTo(array[largerChildIndex]) > 0)
                {
                    largerChildIndex = rightChildIndex;
                }
                //compare the larger child to the current value. If the child is larger, move it up
                // and continue moving through
                if(current.CompareTo(array[largerChildIndex]) < 0)
                {
                    array[index] = array[largerChildIndex];
                    index = largerChildIndex;
                    largerChildIndex = GetLeftChildIndex(index);
                }
                else
                {
                    done = true;
                }

                array[index] = current;
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return (index * 2) + 2;
        }
    }
}
