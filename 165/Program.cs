﻿Solution solution = new Solution();
var res = solution.CheckRecord(2);
Console.WriteLine(res);

public class Solution
{
    public int CheckRecord(int n)
    {
        int MOD = 1000000007;
        //P A L
        var dp = new int[n + 1, 2, 3];
        dp[0, 0, 0] = 1;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, j, k]) % MOD;
                }
            }

            for (int k = 0; k <= 2; k++)
            {
                dp[i, 1, 0] = (dp[i, 1, 0] + dp[i - 1, 0, k]) % MOD;
            }

            for (int j = 0; j <= 1; j++)
            {
                for (int k = 1; k <= 2; k++)
                {
                    dp[i, j, k] = (dp[i, j, k] + dp[i - 1, j, k - 1]) % MOD;
                }
            }

        }
        var res = 0;
        for (int j = 0; j <= 1; j++)
        {
            for (int k = 0; k <= 2; k++)
            {
                res = (res+dp[n, j, k]) % MOD;
            }
        }

        return res;
    }
}