using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSorter<T> : ASorter<T> where T : IComparable<T>
    {
        public InsertionSorter(T[] array) : base(array)
        {

        }

        public override void Sort()
        {
            
        }
    }
}
