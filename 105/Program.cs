using System.Text;


Solution solution = new();
Console.WriteLine(solution.ReverseWords("the sky is blue"));
public class Solution
{
    public string ReverseWords(string s)
    {
        StringBuilder sb = new StringBuilder();
        int right = -1;
        int ml = 0, mr = s.Length - 1;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                ml = i;
                break;
            }
        }

        for (int i = mr; i >= ml; i--)
        {
            if (s[i] != ' ')
            {
                if (right == -1)
                    right = i;
            }

            if ((s[i] == ' ' || i == ml) && right != -1)
            {
                int j = i == ml ? ml : i + 1;
                for (; j <= right; j++)
                {
                    sb.Append(s[j]);
                }
                if (i != ml)
                    sb.Append(" ");
                right = -1;
            }
        }
        return sb.ToString();

    }
}