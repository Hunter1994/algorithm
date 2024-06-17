public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int minPrice = int.MaxValue;
        int max = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else
            {
                if (prices[i] - minPrice > max)
                {
                    max = prices[i] - minPrice;
                }
            }
        }
        return max;
    }
}