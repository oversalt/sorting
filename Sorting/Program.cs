using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        public static void TestSorter(ASorter<int> Sorter)
        {
            Console.WriteLine(Sorter.GetType().Name + " with " + Sorter.Length + " elements.");
            //Print out the array if its size is less than or equal to 50 items
            if (Sorter.Length <= 50)
            {
                Console.WriteLine("Before sort:\n" + Sorter);
            }

            long startTime = Environment.TickCount;
            Sorter.Sort();
            long endTime = Environment.TickCount;

            if (Sorter.Length <= 50)
            {
                Console.WriteLine("After sort:\n" + Sorter);
            }
            Console.WriteLine("Sort took " + (endTime - startTime) + "ms");
        }

        public static void SetupSorterAndSort()
        {
            Console.WriteLine("Enter number of elements to sort: ");
            string input = Console.ReadLine();
            int arraySize = int.Parse(input);
            int[] array = new int[arraySize];
            //Create a random number generating object
            //Note that it is "Seeded" with the current time in milliseconds
            Random r = new Random(Environment.TickCount);
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = r.Next(array.Length * 100);
                //Do this to create an already sorted array
                //array[i] = i;
            }
            TestSorter(new InsertionSorter<int>(array));
        }

        static void Main(string[] args)
        {
            SetupSorterAndSort();
        }
    }
}
