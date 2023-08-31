using intervie.Models;

namespace intervie.Service
{
    public class MergeSort
    {

        public static  ArrayListImpl MergeSortImpl(ArrayListImpl unsorted)
        {
            if (unsorted.Size <= 1) return unsorted;

            ArrayListImpl left = new ArrayListImpl();
            ArrayListImpl right = new ArrayListImpl();

            int mid = unsorted.Size / 2;
            for (int i = 0; i < mid; i++)
            {
                left.Add(unsorted.GetIntAt(i));
            }

            for (int i = mid; i < unsorted.Size; i++)
            {
                right.Add(unsorted.GetIntAt(i));
            }

            left = MergeSortImpl(left);
            right = MergeSortImpl(right);
            return Merge(left, right);

        }

        public static ArrayListImpl Merge(ArrayListImpl left, ArrayListImpl right)
        {
            ArrayListImpl result = new ArrayListImpl();
            while (left.Size > 0 || right.Size > 0)
            {
                if (left.Size > 0 && right.Size > 0)
                {
                    if (left.GetIntAt(0) <= right.GetIntAt(0))
                    {
                        result.Add(left.GetIntAt(0));
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right.GetIntAt(0));
                        right.RemoveAt(0);
                    }
                }
                else if (left.Size > 0)
                {
                    result.Add(left.GetIntAt(0)); left.RemoveAt(0);
                }
                else if (right.Size > 0)
                {
                    result.Add(right.GetIntAt(0)); right.RemoveAt(0);
                }
            }
            return result;
        }

    }
}
