Solution solution = new Solution();
var res = solution.IncremovableSubarrayCount([3, 7, 2]);
System.Console.WriteLine(res);
public class Solution
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        var n = nums.Length;
        var res = 0;
        int l = 1;
        while (l < n - 1 && nums[l] > nums[l - 1])
            l++;
        res = l + (l < n ? 1 : 0);
        for (int r = n - 2; r >= 0; r--)
        {
            while (l > 0 && nums[l - 1] >= nums[r + 1])
            {
                l--;
            }
            res += l + (l <= r ? 1 : 0);
            if (nums[r] >= nums[r + 1]) break;
        }
        return res;
    }
}