
Solution solution = new();
solution.CoinChange([2], 3);
public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0) return 0;
        var dp = new long[amount + 1];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = int.MaxValue;
        }
        dp[0] = 0;
        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 0; j < coins.Length; j++)
            {
                if (coins[j] <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }
        return dp[amount] > amount ? -1 : Convert.ToInt32(dp[amount]);
    }
}