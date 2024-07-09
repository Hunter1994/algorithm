
using System.Security.Cryptography;

Solution solution = new();
solution.GoodSubsetofBinaryMatrix([[0, 1, 1, 0], [0, 0, 0, 1], [1, 1, 1, 1]]);

public class Solution
{
    public IList<int> GoodSubsetofBinaryMatrix(int[][] grid)
    {
        var dic = new Dictionary<int, int>();
        List<int> res = new List<int>();
        var n = grid.Length;
        var m = grid[0].Length;
        for (int i = 0; i < n; i++)
        {
            var st = 0;
            for (int j = 0; j < m; j++)
            {
                st |= (grid[i][j] << j);
            }
            if (!dic.TryGetValue(st, out var data))
            {
                dic.Add(st, i);
            }
        }

        if (dic.TryGetValue(0, out var v))
        {
            res.Add(v);
            return res;
        }

        foreach (var item in dic)
        {
            foreach (var item2 in dic)
            {
                if ((item.Key & item2.Key) == 0)
                {
                    res.Add(Math.Min(item.Value, item2.Value));
                    res.Add(Math.Max(item.Value, item2.Value));
                    return res;
                }
            }
        }
        return res;

    }
}



