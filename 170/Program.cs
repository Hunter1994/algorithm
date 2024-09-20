/*
输入：nums = [3,5,2,4]
输出：2

2,3,4,5

输入：nums = [9,2,5,4]
输出：4

2,4,5,9
*/
Solution solution = new Solution();
var res = solution.MaxNumOfMarkedIndices([9, 2, 5, 4]);
Console.WriteLine(res);
public class Solution
{
    public int MaxNumOfMarkedIndices(int[] nums)
    {
        var n = nums.Length;
        Array.Sort(nums);
        var l = 0;
        var r = n / 2;
        var res = 0;
        while (l < r)
        {
            var m = l + r + 1 >> 1;
            if (Check(nums, n, m))
            {
                l = m;
                res = m;
            }
            else
            {
                r = m - 1;
            }
        }
        return res * 2;
    }
    private bool Check(int[] nums, int n, int m)
    {
        for (int i = 0; i < m; i++)
        {
            if (nums[i] * 2 > nums[n - m + i])
            {
                return false;
            }
        }
        return true;
    }
}