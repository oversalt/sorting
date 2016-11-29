using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public abstract class ASorter<T> where T: IComparable<T>
    {
        //Attributes
        protected T[] array;

        //Constructor
        public ASorter(T[] array)
        {
            this.array = array;
        }

        //Abstract methods
        public abstract void Sort();

        //Helper methods

        /// <summary>
        /// Swap two values in the array
        /// </summary>
        /// <param name="first">Location of first item to swap</param>
        /// <param name="second">Location/index of the second item to swap</param>
        protected void Swap(int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }


    }
}
