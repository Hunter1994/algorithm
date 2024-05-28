using System.Collections;
using System.Runtime.Intrinsics.X86;

var a = 6m / -132m;


Solution solution = new Solution();
solution.LongestValidParentheses("())");
public class Solution
{
    public int LongestValidParentheses(string s)
    {
        var dp = new int[s.Length];
        int max = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == ')' && i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
            {
                dp[i] = dp[i - 1] + 2;
                if (i - dp[i - 1] - 2 >= 0)
                {
                    dp[i] += dp[i - dp[i - 1] - 2];
                }
                if (dp[i] > max)
                {
                    max = dp[i];
                }
            }
        }

        return max;
    }

    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(s[i]);
            }
            else
            {
                var key = stack.Pop();
                var result = key switch
                {
                    '(' => s[i] == ')' ? true : false,
                    '{' => s[i] == '}' ? true : false,
                    '[' => s[i] == ']' ? true : false,
                    _ => false
                };
                if (!result)
                {
                    stack.Push(key);
                    stack.Push(s[i]);
                }
            }
        }
        return !stack.Any();
    }
}