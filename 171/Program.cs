/*
输入：buses = [10,20], passengers = [2,17,18,19], capacity = 2
输出：16

输入：buses = [10,20,30], passengers = [4,11,13,19,21,25,26], capacity = 2
输出：20

返回你可以搭乘公交车的最晚到达公交站时间
1 <= n, m, capacity <= 105
2 <= buses[i], passengers[i] <= 109

[3][2,4]
*/
Solution solution = new Solution();
var res = solution.LatestTimeCatchTheBus([3], [4], 1);
Console.WriteLine(res);
public class Solution
{
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
    {
        Array.Sort(buses);
        Array.Sort(passengers);
        int j = 0;
        int space = 0;
        for (int i = 0; i < buses.Length; i++)
        {
            var p = 0;
            while (p < capacity && j < passengers.Length && passengers[j] <= buses[i])
            {
                j++;
                p++;
            }
            if (i == buses.Length - 1)
            {
                space = capacity - p;
            }
        }

        if (space > 0)
        {
            if (j == 0 || buses[buses.Length - 1] > passengers[j - 1])
                return buses[buses.Length - 1];
        }

        for (int i = j - 1; i >= 1; i--)
        {
            if (passengers[i] - 1 != passengers[i - 1]) return passengers[i] - 1;
        }
        return passengers[0] - 1;

    }
}