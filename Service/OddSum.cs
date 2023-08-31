namespace intervie.Service
{
    public class OddSum
    {

       public static int sum_odd(int[] nums)
        {
            if (nums.Length==0) return 0;
            int sum = 0;
            bool gate = false;
            foreach (int i in nums)
            {
                if (i % 2 == 1 || i % 2 == -1)
                {
                    if (gate)
                    {
                        sum += Math.Abs(i);
                        gate = false;
                    }
                    else { gate = true; }
                }
            }
            return sum;
        }

    }
}
