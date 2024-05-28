

Solution2 s = new Solution2();
var res = s.FindMedianSortedArrays(new int[0], new int[] { 2, 3 });
Console.WriteLine(res);
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int i = 0;
        int j = 1;
        while (i < nums.Length)
        {
            if (nums[i] + nums[j] == target)
            {
                return new int[] { i, j };
            }
            else
            {
                if (j == nums.Length - 1)
                {
                    while (dic.TryGetValue(nums[++i], out var v) && i < nums.Length)
                    {

                    }
                    j = i + 1;
                    dic.Add(nums[i], nums[i]);
                }
                else
                {
                    j++;
                }
            }
        }
        return null;
    }
}

public class Solution2
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var n = nums1.Length + nums2.Length;
        var arr = new int[n];
        var isjishu = n % 2 == 0;
        int i = 0;
        int j = 0;
        int v = 0;
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] <= nums2[j])
            {
                arr[v++] = nums1[i++];
            }
            else
            {
                arr[v++] = nums2[j++];
            }
        }
        if (i < nums1.Length)
        {
            for (int k = i; k < nums1.Length; k++)
            {
                arr[v++] = nums1[k];
            }
        }
        if (j < nums2.Length)
        {
            for (int k = j; k < nums2.Length; k++)
            {
                arr[v++] = nums2[k];
            }
        }

        if (isjishu)
        {
            return Convert.ToDouble(arr[n / 2 - 1] + arr[n / 2]) / 2d;
        }
        else
        {
            return arr[n / 2];
        }

    }
}