Solution solution = new Solution();
var res = solution.SpecialPerm([1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192]);
Console.WriteLine(res);
public class Solution
{
    private int MOD = 1000000007;
    private int[][] f;
    private int[] nums;
    private int n;
    public int SpecialPerm(int[] nums)
    {
        this.nums = nums;
        n = nums.Length;
        f = new int[1 << n][];
        int res = 0;
        for (int i = 0; i < f.Length; i++)
        {
            f[i] = new int[n];
            Array.Fill(f[i], -1);
        }

        for (int i = 0; i < n; i++)
        {
            res = (res + DFS((1 << n) - 1, i)) % MOD;
        }
        return res;
    }

    private int DFS(int state, int i)
    {
        if (f[state][i] != -1)
            return f[state][i];

        if (state == (1 << i))
            return 1;
        f[state][i] = 0;
        for (int j = 0; j < n; j++)
        {
            if (j == i || (state & (1 << j)) == 0) continue;
            if (nums[j] % nums[i] != 0 && nums[i] % nums[j] != 0) continue;
            f[state][i] = (f[state][i] + DFS(state ^ (1 << i), j)) % MOD;
        }
        return f[state][i];
    }
}