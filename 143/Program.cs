﻿Console.WriteLine((6 >> 0 & 1) == 0);

Solution solution = new Solution();
var res = solution.SpecialPerm([2, 4, 8]);
Console.WriteLine(res);
public class Solution
{
    const int MOD = 1000000007;
    int[] nums;
    int n;
    int[][] f;

    public int SpecialPerm(int[] nums)
    {
        this.nums = nums;
        this.n = nums.Length;
        this.f = new int[1 << n][];
        for (int i = 0; i < 1 << n; i++)
        {
            f[i] = new int[n];
            Array.Fill(f[i], -1);
        }
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res = (res + DFS((1 << n) - 1, i)) % MOD;
        }
        return res;
    }

    public int DFS(int state, int i)
    {
        if (f[state][i] != -1)
        {
            return f[state][i];
        }
        if (state == (1 << i))
        {
            return 1;
        }
        f[state][i] = 0;
        for (int j = 0; j < n; j++)
        {
            if (i == j || (state >> j & 1) == 0)
            {
                continue;
            }
            if (nums[i] % nums[j] != 0 && nums[j] % nums[i] != 0)
            {
                continue;
            }
            f[state][i] = (f[state][i] + DFS(state ^ (1 << i), j)) % MOD;
        }
        return f[state][i];
    }
}
