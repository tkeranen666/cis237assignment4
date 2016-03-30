using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        private static IComparable[] aux;

        public void sort(IComparable[] tempArray, int lengthOfCollection)
        {
            aux = new IComparable[tempArray.Length];
            if (tempArray != null)
            {
                sort(tempArray, 0, lengthOfCollection);
            }
            else
            {
                Console.WriteLine("ERROR!");
            }
        }

        private static void sort(IComparable[] tempArray, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(tempArray, lo, mid);
            sort(tempArray, mid + 1, hi);
            merge(tempArray, lo, mid, hi);
        }

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
