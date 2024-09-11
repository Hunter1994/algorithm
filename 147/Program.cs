﻿Solution solution = new();
// var res = solution.MinimumMoves([1, 1, 0, 0, 0, 1, 1, 0, 0, 1], 3, 1);
// var res = solution.MinimumMoves([1, 0, 1, 0, 0, 0, 0, 1], 3, 0);
// var res = solution.MinimumMoves([1, 0, 1, 0, 1], 2, 0);
// var res = solution.MinimumMoves([1, 1, 0, 0, 0, 1, 1, 0, 0, 1], 3, 1);
var res = solution.MinimumMoves([1, 1], 1, 2);
System.Console.WriteLine(res);
public class Solution
{
    public long MinimumMoves(int[] nums, int k, int maxChanges)
    {
        int n = nums.Length;

        long[] indexSum = new long[n + 1], sum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            indexSum[i + 1] = indexSum[i] + nums[i] * i;
            sum[i + 1] = sum[i] + nums[i];
        }
        long res = long.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (F(i, nums) + maxChanges >= k)
            {
                if (k <= F(i, nums))
                {
                    res = Math.Min(res, (long)k - nums[i]);
                }
                else
                {
                    res = Math.Min(res, (long)2 * k - F(i, nums) - nums[i]);
                }
                continue;
            }
            int left = 0, right = n;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int idx1 = Math.Max(i - mid, 0), idx2 = Math.Min(i + mid, n - 1);
                if (sum[idx2 + 1] - sum[idx1] >= k - maxChanges)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            int i1 = Math.Max(i - left, 0), i2 = Math.Min(i + left, n - 1);
            if (sum[i2 + 1] - sum[i1] > k - maxChanges)
            {
                i1++;
            }
            long count1 = sum[i + 1] - sum[i1], count2 = sum[i2 + 1] - sum[i + 1];
            var data = indexSum[i2 + 1] - indexSum[i + 1] - i * count2 + i * count1 - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges;
            res = Math.Min(res, data);
        }
        return res;
    }

    public int F(int i, int[] nums)
    {
        int x = nums[i];
        if (i - 1 >= 0)
        {
            x += nums[i - 1];
        }
        if (i + 1 < nums.Length)
        {
            x += nums[i + 1];
        }
        return x;
    }
}
