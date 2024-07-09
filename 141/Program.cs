public class Solution
{
    public int[] NextGreaterElements(int[] nums)
    {
        var n = nums.Length;
        int[] res = new int[n];
        Array.Fill(res, -1);
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < n * 2 - 1; i++)
        {
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i % n])
            {
                res[stack.Pop()] = nums[i % n];
            }
            stack.Push(i % n);
        }
        return res;
    }

}