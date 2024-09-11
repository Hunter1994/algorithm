Solution solution = new Solution();
var res = solution.MaxmiumScore([3, 3, 1], 1);
Console.WriteLine(res);

public class Solution
{
    public int MaxmiumScore(int[] cards, int cnt)
    {
        Array.Sort(cards);
        var res = 0;
        var temp = 0;
        var minJ = -1;
        var minO = -1;
        for (int m = cards.Length - 1; m >= cards.Length - cnt; m--)
        {
            temp += cards[m];
            if ((cards[m] & 1) != 0)
            {
                minJ = cards[m];
            }
            else
            {
                minO = cards[m];
            }
        }
        if ((temp & 1) == 0) return temp;

        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) != 0 && minO != -1)
            {
                res = Math.Max(res, temp - minO + cards[i]);
                break;
            }
        }
        for (int i = cards.Length - cnt - 1; i >= 0; i--)
        {
            if ((cards[i] & 1) == 0 && minJ != -1)
            {
                res = Math.Max(res, temp - minJ + cards[i]);
                break;
            }
        }
        return res;

    }
}