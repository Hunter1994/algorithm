﻿Solution solution = new();
var res = solution.SumOfPowers([1, 2, 3, 4], 3);
System.Console.WriteLine(res);

public class Solution
{
    const int MOD = 1000000007, INF = 0x3f3f3f3f;

    public int SumOfPowers(int[] nums, int k)
    {
        int n = nums.Length;
        int res = 0;
        IDictionary<int, int>[][] d = new IDictionary<int, int>[n][];
        for (int i = 0; i < n; i++)
        {
            d[i] = new IDictionary<int, int>[k + 1];
            for (int j = 0; j <= k; j++)
            {
                d[i][j] = new Dictionary<int, int>();
            }
        }
        Array.Sort(nums);
        for (int i = 0; i < n; i++)
        {
            d[i][1].Add(INF, 1);
            for (int j = 0; j < i; j++)
            {
                int diff = Math.Abs(nums[i] - nums[j]);
                for (int p = 2; p <= k; p++)
                {
                    foreach (KeyValuePair<int, int> pair in d[j][p - 1])
                    {
                        int v = pair.Key, cnt = pair.Value;
                        int currKey = Math.Min(diff, v);
                        d[i][p].TryAdd(currKey, 0);
                        d[i][p][currKey] = (d[i][p][currKey] + cnt) % MOD;
                    }
                }
            }

            foreach (KeyValuePair<int, int> pair in d[i][k])
            {
                int v = pair.Key, cnt = pair.Value;
                res = (int)((res + 1L * v * cnt % MOD) % MOD);
            }
        }
        return res;
    }
}