
//A>1
//连续L>2
Solution solution = new Solution();
var res = solution.CheckRecord(10);
Console.WriteLine(res);

public class Solution
{
    private const int MOD = 1000000007;
    public int CheckRecord(int n)
    {
        int res = 0;
        string atten = "ALP";
        CheckRecord(atten, 0, n, 0, 0, ref res);
        return res;
    }
    private void CheckRecord(string atten, int i, int n, int a, int l, ref int res)
    {
        if (a >= 2) return;
        if (l > 2) return;
        if (i >= n)
        {
            res = (res + 1) % MOD;
            return;
        };
        foreach (var item in atten)
        {
            int aa = 0, ll = 0;
            if (item == 'A')
                aa++;

            if (item == 'L')
            {
                ll = l + 1;
            }
            else
                ll = 0;
            CheckRecord(atten, i + 1, n, a + aa, ll, ref res);
        }
    }

}