new Solution().SumOfTheDigitsOfHarshadNumber(18);

public class Solution
{
    public int SumOfTheDigitsOfHarshadNumber(int x)
    {
        var num = 0;
        for (int i = x; i > 0; i /= 10)
        {
            num += i % 10;
        }
        if (x % num == 0) return num;
        else return -1;
    }
}