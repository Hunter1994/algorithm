
using Microsoft.VisualBasic;

Solution s = new();
// char[][] grid = new char[4][];
// grid[0] = ['1', '1', '0', '0', '0'];
// grid[1] = ['1', '1', '0', '0', '0'];
// grid[2] = ['0', '0', '1', '0', '0'];
// grid[3] = ['0', '0', '0', '1', '1'];

char[][] grid = new char[3][];
grid[0] = ['1', '1', '1'];
grid[1] = ['0', '1', '0'];
grid[2] = ['1', '1', '1'];


s.NumIslands(grid);

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int num = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int k = 0; k < grid[i].Length; k++)
            {
                if (grid[i][k] == '1')
                {
                    num++;
                    DFS(grid, i, k);
                }
            }
        }

        return num;
    }
    private void DFS(char[][] grid, int x, int y)
    {
        if (grid[x][y] == '0') return;
        grid[x][y] = '0';
        if (grid[x].Length > (y + 1))
        {
            DFS(grid, x, y + 1);
        }
        if ((y - 1) >= 0)
        {
            DFS(grid, x, y - 1);
        }
        if (grid.Length > (x + 1))
        {
            DFS(grid, x + 1, y);
        }
        if ((x - 1) >= 0)
        {
            DFS(grid, x - 1, y);
        }

    }
}