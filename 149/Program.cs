public class Solution
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        int res = 0;
        var n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j >= 0; j--)
            {
                if (Sort(nums, n, j, i)) res++;
            }
        }
        return res;
    }

    private bool Sort(int[] nums, int n, int removeStart, int removeEnd)
    {
        int d = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            if (i >= removeStart && i <= removeEnd) continue;
            if (nums[i] > d)
                d = nums[i];
            else
            {
                return false;
            }

        }
        return true;
    }
}