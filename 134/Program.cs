
Solution solution = new();
var res = solution.IsMatch("aa", "a*");
Console.WriteLine(res);
public class Solution
{
    public bool IsMatch(string s, string p)
    {
        var data = new bool[s.Length + 1][];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = new bool[p.Length + 1];
        }

        data[0][0] = true;

        for (int i = 0; i <= s.Length; i++)
        {
            for (int j = 1; j <= p.Length; j++)
            {
                if (p[j - 1] == '*')
                {
                    data[i][j] = data[i][j - 2];
                    if (IsMatch(s, p, i, j - 1))
                    {
                        data[i][j] = data[i][j] || data[i - 1][j];
                    }
                }
                else
                {
                    if (IsMatch(s, p, i, j))
                    {
                        data[i][j] = data[i - 1][j - 1];
                    }
                }
            }
        }
        return data[s.Length][p.Length];
    }
    bool IsMatch(string s, string p, int i, int j)
    {
        if (i == 0) return false;
        if (p[j - 1] == '.') return true;
        return s[i - 1] == p[j - 1];
    }

}