Solution solution = new();
// var res = solution.SumOfPowers([1, 2, 3, 4], 3);
// var res = solution.SumOfPowers([-3, -7, -9, 5, -8], 3);
var res = solution.SumOfPowers([-24, -921, 119, -291, -65, -628, 372, 274, 962, -592, -10, 67, -977, 85, -294, 349, -119, -846, -959, -79, -877, 833, 857, 44, 826, -295, -855, 554, -999, 759, -653, -423, -599, -928], 19);
System.Console.WriteLine(res);

public class Solution
{
    public int SumOfPowers(int[] nums, int k)
    {
        int MOD = 1000000007;
        int[] r = new int[k];
        for (int m = 0; m < k; m++)
        {
            r[m] = m;
        }

        long res = 0;
        while (true)
        {
            int i1 = 0;
            int j1 = i1 + 1;
            var min = long.MaxValue;
            // while (i1 < r.Length - 1)
            // {
            //     var e = Math.Abs(nums[r[j1]] - nums[r[i1]]);
            //     if (min > e)
            //     {
            //         min = e;
            //     }
            //     if (j1 == r.Length - 1)
            //     {
            //         i1++;
            //         j1 = i1 + 1;
            //     }
            //     else
            //         j1++;
            // }
            // res += min;
            for (int m = 0; m < k; m++)
            {
                Console.Write(nums[r[m]] + ",");
            }
            Console.Write("=" + min);
            Console.WriteLine();


            if (r[0] == nums.Length - k)
                break;
            for (int i = k - 1; i >= 0; i--)
            {
                if (r[i] <= nums.Length - 1 - (k - i))
                {
                    r[i]++;
                    var p = i;
                    while (p < k - 1 && r[p] + 1 < r[p + 1])
                    {
                        r[p + 1] = r[p] + 1;
                        p++;
                    }
                    break;
                }
            }
        }
        return Convert.ToInt32(res % MOD);
    }
}