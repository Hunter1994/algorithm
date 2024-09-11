Solution solution = new Solution();
var res = solution.MaxmiumScore([13, 12, 10, 19, 19, 4, 16, 10, 2, 9, 2, 13, 13, 15, 5, 19, 3, 13, 17, 4, 18, 19, 8, 1, 19, 18, 17, 14, 6, 9, 6, 11, 4, 1, 16, 6, 19, 15, 20, 18, 2, 14, 17, 9, 13, 15, 1, 11, 20, 15, 18, 17, 12, 20, 11, 14, 7, 1, 8, 12, 19, 17, 11, 17, 19, 14, 7, 20, 3, 3, 5, 5, 18, 15, 6, 15, 7, 7, 1, 17, 3, 5, 7, 12, 13, 18, 13, 17, 20, 5, 15, 10, 11, 19, 1, 16, 18], 19);
Console.WriteLine(res);

public class Solution
{
    public int MaxmiumScore(int[] cards, int cnt)
    {
        var res = 0;
        int[] index = new int[cnt];
        for (int i = 0; i < index.Length; i++)
        {
            index[i] = i;
        }

        while (true)
        {
            var data = 0;
            for (int i = 0; i < index.Length; i++)
            {
                data += cards[index[i]];
                Console.Write(index[i] + " ");
            }
            Console.WriteLine();

            if (data % 2 == 0 && data > res) res = data;

            if (index[0] == cards.Length - cnt)
                break;

            if (index[cnt - 1] < cards.Length - 1)
            {
                index[cnt - 1]++;
            }
            else
            {
                for (int i = index.Length - 2; i >= 0; i--)
                {
                    if (index[i + 1] != index[i] + 1)
                    {
                        index[i]++;
                        for (int j = i + 1; j < index.Length; j++)
                        {
                            index[j] = index[j - 1] + 1;
                        }
                        break;
                    }
                }

            }
        }
        return res;
    }
}