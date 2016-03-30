using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        private static IComparable[] aux; // Create a new array with IComparable

        // Method recieves variables passed in by DroidCollection
        public void Sort(IComparable[] tempArray, int lengthOfCollection)
        {
            aux = new IComparable[tempArray.Length]; // Load aux with values from tempArray

            // If tempArray is not empty call next sort method
            if (tempArray != null)
            {
                Sort(tempArray, 0, lengthOfCollection);
            }
            else
            {
                Console.WriteLine("ERROR!"); // If array is empty display an error
            }
        }

        // Method sorts through and separates values from array
        private static void Sort(IComparable[] tempArray, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;

            Sort(tempArray, lo, mid);

            Sort(tempArray, mid + 1, hi);

            merge(tempArray, lo, mid, hi);
        }

        // Method merges sorted values again and returns the sorted array to the Droid Collection
        public static void merge(IComparable[] tempArray, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = tempArray[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    tempArray[k] = aux[j++];
                }
                else if (j > hi)
                {
                    tempArray[k] = aux[i++];
                }
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    tempArray[k] = aux[j++];
                }
                else
                {
                    tempArray[k] = aux[i++];
                }
            }
        }
    }
}
