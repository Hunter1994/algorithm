Solution solution = new();
var res = solution.MinimumTotal([[2], [3, 4], [6, 5, 7], [4, 1, 8, 3]]);
Console.WriteLine(res);
public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        var data = new int[triangle.Count][];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = new int[triangle[i].Count];
        }

        data[0][0] = triangle[0][0];

        for (int i = 1; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                var v = int.MaxValue;
                if (j < data[i - 1].Length)
                {
                    v = triangle[i][j] + data[i - 1][j];
                }

                if (j - 1 >= 0)
                {
                    v = Math.Min(triangle[i][j] + data[i - 1][j - 1], v);
                }

                data[i][j] = v;
            }
        }
        return data[triangle.Count - 1].Min();
    }
}