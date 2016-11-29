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

        public int Length
        {
            get { return array.Length; }
        }

        //Set up a property that will allow the use of [] brackets on this class
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            foreach(T tVal in array)
            {
                sb.Append(tVal);
                sb.Append(", ");
            }
            if(sb.Length > 1)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
