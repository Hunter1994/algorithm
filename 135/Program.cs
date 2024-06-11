
Solution solution = new();
var arr = new int[3][];
arr[0] = [1, 3, 1];
arr[1] = [1, 5, 1];
arr[2] = [4, 2, 1];

var res = solution.MinPathSum(arr);
Console.WriteLine(res);
public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        var data = new int[grid.Length][];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = new int[grid[i].Length];
        }
        data[0][0] = grid[0][0];
        for (int i = 1; i < data.Length; i++)
        {
            data[i][0] = grid[i][0] + data[i - 1][0];
        }

        for (int i = 1; i < grid[0].Length; i++)
        {
            data[0][i] = grid[0][i] + data[0][i - 1];
        }

        for (int i = 1; i < data.Length; i++)
        {
            for (int j = 1; j < data[i].Length; j++)
            {
                data[i][j] = Math.Min(grid[i][j] + data[i][j - 1], grid[i][j] + data[i - 1][j]);
            }
        }

        return data[grid.Length - 1][grid[grid.Length - 1].Length - 1];
    }
}