

public class Solution
{
    public long MinimumMoves(int[] nums, int k, int maxChanges)
    {
        var res = long.MaxValue;
        var n = nums.Length;
        var indexSum = new long[n + 1];
        var sum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            sum[i + 1] += sum[i] + nums[i];
            indexSum[i + 1] += indexSum[i] + nums[i] * i;
        }


        for (int i = 0; i < n; i++)
        {
            if (f(nums, i) >= k - maxChanges)
            {
                if (f(nums, i) > k)
                {
                    res = Math.Min(res, k - nums[i]);
                }
                else
                {
                    res = Math.Min(res, 2 * k - f(nums, i) - nums[i]);
                }
                continue;
            }
            var left = 0; var right = n;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                var l1 = Math.Max(i - mid, 0); var l2 = Math.Min(i + mid, n - 1);
                if (sum[l2 + 1] - sum[l1] >= k - maxChanges)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            var i1 = Math.Max(i - left, 0); var i2 = Math.Min(i + left, n - 1);
            if (sum[i2 + 1] - sum[i1] > k - maxChanges)
            {
                i1++;
            }
            var count1 = sum[i + 1] - sum[i1]; var count2 = sum[i2 + 1] - sum[i + 1];
            var data = indexSum[i2 + 1] - indexSum[i + 1] - count2 * i + count1 * i - (indexSum[i + 1] - indexSum[i1]) + 2 * maxChanges;
            res = Math.Min(res, data);
        }



        return res;
    }
    int f(int[] nums, int i)
    {
        var res = nums[i];
        if (i - 1 >= 0)
        {
            res += nums[i - 1];
        }

        if (i + 1 < nums.Length)
        {
            res += nums[i + 1];
        }
        return res;
    }
}