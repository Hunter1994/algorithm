Solution solution = new Solution();
var res = solution.FindIntegers(1000000000);
Console.WriteLine(res);

public class Solution
{
    public int FindIntegers(int n)
    {
        var res = 0;
        int[] dp = new int[31];
        dp[0] = dp[1] = 1;
        for (int i = 2; i < dp.Count(); i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        var pre = 0;
        for (int i = 29; i >= 0; i--)
        {
            var d = 1 << i;
            if ((d & n) > 0)
            {
                res += dp[i + 1];

                if (pre == 1) break;

                pre = 1;
            }
            else
            {
                pre = 0;
            }
            if (i == 0)
                ++res;
        }


        return res;
    }
}