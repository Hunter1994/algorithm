using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

int aaa = -2147483648;


Solution solution = new Solution();
// Console.WriteLine(solution.MyAtoi(" 01a"));
// Console.WriteLine(solution.MyAtoi("    "));
// Console.WriteLine(solution.MyAtoi("  a01a  "));
Console.WriteLine(solution.MyAtoi("   -42"));

public class Solution
{
    public int MyAtoi(string s)
    {
        int f = 10;
        int num = 0;
        int start = 0;
        int q = 1;
        for (; start < s.Length; start++)
        {
            if (s[start] != ' ')
            {
                break;
            }
        }
        if (start < s.Length && (s[start] == '+' || s[start] == '-'))
        {
            if (s[start] == '-')
                q *= -1;
            start++;
        }


        for (int i = start; i < s.Length; i++)
        {
            if (!Regex.IsMatch(s[i].ToString(), "[0-9]"))
            {
                return num;
            }
            try
            {
                checked
                {
                    num = (num * f);
                    if (q < 0 && num > 0)
                    {
                        num *= q;
                    }
                    num = num + Convert.ToInt32(s[i].ToString()) * q;
                }
            }
            catch
            {
                if (num < 0) return int.MinValue;
                else
                    return int.MaxValue;
            }

        }

        return num;
    }

}