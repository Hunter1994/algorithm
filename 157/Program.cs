public class Solution
{
    const int MOD = 1000000007, INF = 0x3f3f3f3f;
    public int SumOfPowers(int[] nums, int k)
    {
        var res = 0;
        Array.Sort(nums);
        Dictionary<int, int>[][] d = new Dictionary<int, int>[nums.Length][];
        for (int i = 0; i < d.Count(); i++)
        {
            d[i] = new Dictionary<int, int>[k + 1];
            for (int m = 0; m <= k; m++)
            {
                d[i][m] = new Dictionary<int, int>();
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            d[i][1].TryAdd(INF, 1);

            for (int j = 0; j < i; j++)
            {
                var diff = Math.Abs(nums[i] - nums[j]);

                for (int p = 2; p <= k; p++)
                {
                    foreach (var item in d[j][p - 1])
                    {
                        var v = Math.Min(diff, item.Key);
                        d[i][p].TryAdd(v, 0);
                        d[i][p][v] = (d[i][p][v] + item.Value) % MOD;
                    }
                }

            }

            foreach (var item in d[i][k])
            {
                res = (int)(res + 1L * item.Key * item.Value % MOD) % MOD;
            }

        }
        return res;


    }
}