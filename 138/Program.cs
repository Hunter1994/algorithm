Solution solution = new();
var res = solution.MaxProduct([0, 10, 10, 10, 10, 10, 10, 10, 10, 10, -10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0]);
Console.WriteLine(res);
public class Solution
{
    public int MaxProduct(int[] nums)
    {
        var max = new decimal[nums.Length];
        var min = new decimal[nums.Length];
        max[0] = nums[0];
        min[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            max[i] = Math.Max(Math.Max(max[i - 1] * Convert.ToDecimal(nums[i]), Convert.ToDecimal(nums[i])), min[i - 1] * Convert.ToDecimal(nums[i]));
            min[i] = Math.Min(Math.Min(max[i - 1] * Convert.ToDecimal(nums[i]), Convert.ToDecimal(nums[i])), min[i - 1] * Convert.ToDecimal(nums[i]));
        }

        return Convert.ToInt32(max.Max());
    }

}