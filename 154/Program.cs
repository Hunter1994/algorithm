Solution solution = new Solution();
var res = solution.MaximumDetonation([[1, 1, 5], [10, 10, 5]]);
Console.WriteLine(res);

public class Solution
{
    public int MaximumDetonation(int[][] bombs)
    {
        int maxBombs = 0;
        for (int i = 0; i < bombs.Length; i++)
        {
            var bombCount = 1;
            Queue<(int, int[])> queue = new Queue<(int, int[])>();

            bool[] isBomb = new bool[bombs.Length];
            isBomb[i] = true;
            queue.Enqueue((i, bombs[i]));
            while (queue.Count > 0)
            {
                var b = queue.Dequeue();
                for (int j = 0; j < bombs.Length; j++)
                {
                    if (isBomb[j]) continue;
                    if (op(bombs[j], b.Item2) <= b.Item2[2])
                    {
                        bombCount++;
                        isBomb[j] = true;
                        queue.Enqueue((j, bombs[j]));
                    }
                }
            }

            if (bombCount > maxBombs) maxBombs = bombCount;
        }
        return maxBombs;
    }

    private double op(int[] a, int[] b)
    {
        var x = Math.Abs(Math.Pow(b[0] - a[0], 2));
        var y = Math.Abs(Math.Pow(b[1] - a[1], 2));
        var d = Math.Sqrt(x + y);
        return d;
    }

}