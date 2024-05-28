using System.Text;

Solution solution = new();
solution.SolveNQueens(4);

public class Solution
{

    public IList<IList<string>> SolveNQueens(int n)
    {
        int[] result = new int[n];
        var res = new List<IList<string>>();
        cal8Queens(res, result, 0, n);
        return res;
    }

    private void cal8Queens(List<IList<string>> res, int[] result, int row, int n)
    {
        if (row == n)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < result.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < n; j++)
                {
                    if (j == result[i])
                    {
                        sb.Append("Q");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }
                list.Add(sb.ToString());
            }
            res.Add(list);
        }
        for (int cloumn = 0; cloumn < n; cloumn++)
        {
            if (isok(result, row, cloumn))
            {
                result[row] = cloumn;
                cal8Queens(res, result, row + 1, n);
            }
        }
    }
    private bool isok(int[] result, int row, int cloumn)
    {
        var left = cloumn - 1;
        var right = cloumn + 1;

        for (int i = row - 1; i >= 0; i--)
        {
            if (result[i] == cloumn) return false;
            if (result[i] == left) return false;
            if (result[i] == right) return false;
            left--;
            right++;
        }
        return true;
    }
}