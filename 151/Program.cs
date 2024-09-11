public class Solution
{
    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        int[] res = new int[2];
        var n1Dic = nums1.Distinct().ToDictionary(r => r, r => r);
        var n2Dic = nums2.Distinct().ToDictionary(r => r, r => r);

        for (int i = 0; i < nums1.Count(); i++)
        {
            if (n2Dic.TryGetValue(nums1[i], out var a))
            {
                res[0]++;
            }
        }
        for (int i = 0; i < nums2.Count(); i++)
        {
            if (n1Dic.TryGetValue(nums2[i], out var a))
            {
                res[1]++;
            }
        }
        return res;
    }
}