﻿
// while (true)
// {
//     var count = 0;
//     var num = Convert.ToInt32(Console.ReadLine());
//     while (num > 0)
//     {
//         count++;
//         num &= num - 1;
//     }
//     Console.WriteLine(count);

// }

var aa = "1024";
var aaa = aa[3] - '0';
Console.WriteLine(aaa);

Solution solution = new Solution();
var res = solution.CountSpecialNumbers(1034);
Console.WriteLine(res);


public class Solution
{
    Dictionary<int, int> memo = new Dictionary<int, int>();

    public int CountSpecialNumbers(int n)
    {
        string nStr = n.ToString();
        int res = 0;
        int prod = 9;
        for (int i = 0; i < nStr.Length - 1; i++)
        {
            res += prod;
            prod *= 9 - i;
        }
        res += Dp(0, false, nStr);
        return res;
    }

    public int Dp(int mask, bool prefixSmaller, string nStr)
    {
        if (CountOnes(mask) == nStr.Length)
        {
            return 1;
        }
        int key = mask * 2 + (prefixSmaller ? 1 : 0);
        if (!memo.ContainsKey(key))
        {
            int res = 0;
            int lowerBound = mask == 0 ? 1 : 0;
            int upperBound = prefixSmaller ? 9 : nStr[CountOnes(mask)] - '0';
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (((mask >> i) & 1) == 0)
                {
                    res += Dp(mask | (1 << i), prefixSmaller || i < upperBound, nStr);
                }
            }
            memo[key] = res;
        }
        return memo[key];
    }

    public static int CountOnes(int number)
    {
        int count = 0;
        while (number > 0)
        {
            count++;
            number &= number - 1;
        }
        return count;
    }
}

