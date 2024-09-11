using System.Reflection.Metadata.Ecma335;
using System.Text;

char c = '0';
Console.WriteLine((int)c);
c = '1';
Console.WriteLine((int)c);
c = 'A';
Console.WriteLine(c.ToString());

Solution solution = new Solution();
var res = solution.ClearDigits("cb34");
Console.WriteLine(res);

//48 57
public class Solution
{
    public string ClearDigits(string s)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
            {
                var vv = stack.Peek();
                if (!Char.IsDigit(vv))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            else
            {
                stack.Push(s[i]);
            }
        }
        StringBuilder sb = new StringBuilder();
        GetResult(stack, sb);
        return sb.ToString();
    }
    private void GetResult(Stack<char> stack, StringBuilder sb)
    {
        if (stack.Count() == 0) return;
        var res = stack.Pop();
        GetResult(stack, sb);
        sb.Append(res);
    }
}