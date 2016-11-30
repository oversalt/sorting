using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public InsertionSorter(T[] array) : base(array) { }

        public override void Sort()
        {
            //Loop through the unsorted part of the array
            for (int i = 1; i < this.Length; i++)
            {
                InsertInOrder(i);
            }
        }

        public void InsertInOrder(int indexUnsorted)
        {
            //Rob's code
            //Element we are trying to put into position
            T unsortedElement = array[indexUnsorted];
            //index --> location of value in the sorted part of the list currently comparing to
            int index = indexUnsorted - 1;
            while (index >= 0 && unsortedElement.CompareTo(array[index]) < 0)
            {
                //Shuffle the current sorted item one location to the right
                array[index + 1] = array[index];
                index--;
            }
            //Put the unsorted element into the correct location
            array[index + 1] = unsortedElement;

            // My code
            //while(indexUnsorted > 0 && array[indexUnsorted].CompareTo(array[indexUnsorted - 1]) < 0)
            //{
            //    Swap(indexUnsorted, indexUnsorted - 1);
            //    indexUnsorted--;
            //}
        }
    }
}
