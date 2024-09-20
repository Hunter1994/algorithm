public class Solution
{
    public int CountSpecialNumbers(int n)
    {
        if (n < 10) return n;
        var dp = new int[(n / 10) + 1, 10];
        int index = 1;
        int sum = 9;
        for (int i = 1; i <= 9; i++)
        {
            dp[index, i] = i;
        }




    }
}