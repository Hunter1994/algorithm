Solution solution = new();
var res = solution.MaxIncreasingCells([[1, -8], [4, 4], [-3, -9]]);
Console.WriteLine(res);

public class Solution
{
    public int MaxIncreasingCells(int[][] mat)
    {
        Dictionary<int, List<int[]>> dic = new Dictionary<int, List<int[]>>();
        int[] row = new int[mat.Length];
        int[] col = new int[mat[0].Length];
        for (int i = 0; i < mat.Length; i++)
        {
            for (int j = 0; j < mat[0].Length; j++)
            {
                dic.TryAdd(mat[i][j], new List<int[]>());
                dic[mat[i][j]].Add([i, j]);
            }
        }

        var keys = dic.Keys.ToArray();
        Array.Sort(keys);

        for (int i = 0; i < keys.Length; i++)
        {
            var positions = dic[keys[i]];
            var res = new List<int>();
            for (int j = 0; j < positions.Count; j++)
            {
                res.Add(Math.Max(row[positions[j][0]], col[positions[j][1]]) + 1);
            }
            for (int j = 0; j < positions.Count; j++)
            {
                row[positions[j][0]] = Math.Max(res[j], row[positions[j][0]]);
                col[positions[j][1]] = Math.Max(res[j], col[positions[j][1]]);
            }

        }
        return row.Max();

    }
}