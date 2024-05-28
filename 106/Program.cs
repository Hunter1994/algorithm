using System.Text.RegularExpressions;

Solution solution = new Solution();
// Console.WriteLine(solution.MyAtoi(" 01a"));
// Console.WriteLine(solution.MyAtoi("    "));
// Console.WriteLine(solution.MyAtoi("  a01a  "));
Console.WriteLine(solution.MyAtoi("words and 987"));

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
        for (int i = start; i < s.Length; i++)
        {

            if ((s[i] == '+' || s[i] == '-') && i + 1 < s.Length && Regex.IsMatch(s[i + 1].ToString(), "[0-9]"))
            {
                if (s[i] == '-')
                    q *= -1;
            }


            if (!Regex.IsMatch(s[i].ToString(), "[0-9]"))
            {
                if (num > 0)
                    return num;
                else
                    continue;
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
                return num;
            }

        }

        return num;
    }

}