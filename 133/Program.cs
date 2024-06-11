Solution solution = new Solution();
var res = solution.isMatch("", "a*");
Console.WriteLine(res);

class Solution
{
    public bool isMatch(String s, String p)
    {
        int m = s.Length;
        int n = p.Length;

        bool[][] f = new bool[m + 1][];
        for (int i = 0; i < f.Length; i++)
        {
            f[i] = new bool[n + 1];
        }

        f[0][0] = true;
        for (int i = 0; i <= m; ++i)
        {
            for (int j = 1; j <= n; ++j)
            {
                if (p[j - 1] == '*')
                {
                    f[i][j] = f[i][j - 2];
                    if (matches(s, p, i, j - 1))
                    {
                        f[i][j] = f[i][j] || f[i - 1][j];
                    }
                }
                else
                {
                    if (matches(s, p, i, j))
                    {
                        f[i][j] = f[i - 1][j - 1];
                    }
                }
            }
        }
        return f[m][n];
    }

    public bool matches(String s, String p, int i, int j)
    {
        if (i == 0)
        {
            return false;
        }
        if (p[j - 1] == '.')
        {
            return true;
        }
        return s[i - 1] == p[j - 1];
    }
}
