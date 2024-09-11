Solution solution = new Solution();
var res = solution.MinimumAddedInteger([10, 2, 8, 7, 5, 6, 7, 10], [5, 8, 5, 3, 8, 4]);
Console.WriteLine(res);
public class Solution
{
    public int MinimumAddedInteger(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        var m = nums1.Length;
        var n = nums2.Length;
        foreach (var i in new int[] { 2, 1, 0 })
        {
            var left = i + 1; var right = 1;
            var v = nums2[0] - nums1[i];
            while (left < m && right < n)
            {
                if (nums2[right] - nums1[left] == v)
                {
                    right++;
                }
                left++;
            }
            if (right == n) return v;
        }
        return 0;
    }



}