Solution s = new();

char[][] board = new char[9][];
// board[0] = ['5', '3', '.', '.', '7', '.', '.', '.', '.'];
// board[1] = ['6', '.', '.', '1', '9', '5', '.', '.', '.'];
// board[2] = ['.', '9', '8', '.', '.', '.', '.', '6', '.'];
// board[3] = ['8', '.', '.', '.', '6', '.', '.', '.', '3'];
// board[4] = ['4', '.', '.', '8', '.', '3', '.', '.', '1'];
// board[5] = ['7', '.', '.', '.', '2', '.', '.', '.', '6'];
// board[6] = ['.', '6', '.', '.', '.', '.', '2', '8', '.'];
// board[7] = ['.', '.', '.', '4', '1', '9', '.', '.', '5'];
// board[8] = ['.', '.', '.', '.', '8', '.', '.', '7', '9'];

board[0] = ['.', '.', '4', '.', '.', '.', '6', '3', '.'];
board[1] = ['.', '.', '.', '.', '.', '.', '.', '.', '.'];
board[2] = ['5', '.', '.', '.', '.', '.', '.', '9', '.'];
board[3] = ['.', '.', '.', '5', '6', '.', '.', '.', '.'];
board[4] = ['4', '.', '3', '.', '.', '.', '.', '.', '1'];
board[5] = ['.', '.', '.', '7', '.', '.', '.', '.', '.'];
board[6] = ['.', '.', '.', '5', '.', '.', '.', '.', '.'];
board[7] = ['.', '.', '.', '.', '.', '.', '.', '.', '.'];
board[8] = ['.', '.', '.', '.', '.', '.', '.', '.', '.'];

var res = s.IsValidSudoku(board);
Console.WriteLine(res);

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        for (int k = 0; k < board.Length; k++)
        {
            bool[] b1 = new bool[board[k].Length + 1];
            bool[] b2 = new bool[board.Length + 1];
            for (int i = 0; i < board[k].Length; i++)
            {
                if (board[k][i] != '.')
                {
                    var num = Convert.ToInt32(board[k][i].ToString());
                    if (b1[num])
                    {
                        return false;
                    }
                    b1[num] = true;
                }
                if (board[i][k] != '.')
                {
                    var num = Convert.ToInt32(board[i][k].ToString());
                    if (b2[num])
                    {
                        return false;
                    }
                    b2[num] = true;
                }

                if (k % 3 == 0 && i % 3 == 0)
                {
                    bool[] b3 = new bool[board.Length + 1];
                    bool[][] visited = new bool[3][];
                    for (int m = 0; m < visited.Length; m++)
                    {
                        visited[m] = new bool[3];
                    }
                    if (!Dfs(board, visited, b3, k, i, k + 3, i + 3))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    private bool Dfs(char[][] board, bool[][] visited, bool[] b3, int k, int i, int ek, int ei)
    {
        if (k >= ek || i >= ei) return true;
        if (visited[k % 3][i % 3]) return true;
        visited[k % 3][i % 3] = true;
        if (board[k][i] != '.')
        {
            var num = Convert.ToInt32(board[k][i].ToString());
            if (b3[num])
            {
                return false;
            }
            b3[num] = true;
        }
        var r1 = Dfs(board, visited, b3, k + 1, i, ek, ei);
        var r2 = Dfs(board, visited, b3, k, i + 1, ek, ei);
        return r1 && r2;
    }

}