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
        HashSet<char>[] r = new HashSet<char>[9];
        HashSet<char>[] l = new HashSet<char>[9];
        HashSet<char>[] s = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            r[i] = new HashSet<char>();
            l[i] = new HashSet<char>();
            s[i] = new HashSet<char>();
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int k = 0; k < board[i].Length; k++)
            {
                if (board[i][k] == '.') continue;

                if (!r[i].Add(board[i][k]))
                {
                    return false;
                }
                if (!l[k].Add(board[i][k]))
                {
                    return false;
                }
                if (!s[i / 3 * 3 + k / 3].Add(board[i][k]))
                {
                    return false;
                }
            }
        }
        return true;
    }


}