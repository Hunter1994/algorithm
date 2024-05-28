// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

var a = new Solution();
var res = a.LengthOfLongestSubstring("au");
Console.WriteLine(res);
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int n = s.Length;
        if (n <= 0) return 0;
        if (n == 1) return 1;
        int i = 0;
        int j = 1;
        int max = 0;
        while (j <= n - 1)
        {
            bool isadd = true;
            for (int k = i; k < j; k++)
            {
                if (s[k] == s[j])
                {
                    i++;
                    j = i;
                    isadd = false;
                    break;
                }
            }
            var sum = j - i;
            if (max < sum)
            {
                max = sum;
            }

            if (isadd)
                j++;
        }
        return max;

    }
}