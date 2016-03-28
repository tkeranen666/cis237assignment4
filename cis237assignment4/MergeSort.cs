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

        public void sort(IComparable[] tempArray)
        {
            aux = new IComparable[tempArray.Length];
            if (tempArray != null)
            {
                sort(tempArray, 0, tempArray.Length - 1);
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
                else if (Convert.ToDecimal(aux[j]) < Convert.ToDecimal(aux[i]))
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
