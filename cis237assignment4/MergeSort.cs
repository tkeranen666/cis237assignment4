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

        public static void sort(IComparable[] a)
        {
            aux = new IComparable[a.Length];
            sort(a, 0, a.Length - 1);
        }

        private static void sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            sort(a, lo, mid);
            sort(a, mid + 1, hi);
            
        }

        public static void merge(IComparable[] a, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else if (j > hi)
                {
                    a[k] = aux[i++];
                }
                else if (Convert.ToDecimal(aux[j]) < Convert.ToDecimal(aux[i]))
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }
    }
}
