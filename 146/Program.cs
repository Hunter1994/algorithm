Solution solution = new Solution();

var res = solution.MinimumMoves([1, 0, 1, 0, 1], 3, 0);
// var res = solution.MinimumMoves([0, 0, 0, 0], 2, 3);
Console.WriteLine(res);
public class Solution
{
    public long MinimumMoves(int[] nums, int k, int maxChanges)
    {
        int selectIndex = 1;
        int maxValue = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] > 0)
            {
                selectIndex = i;
                maxValue = 1;
                break;
            }
        }



        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i - 1] + nums[i] + nums[i + 1] > maxValue && nums[i] == 1)
            {
                maxValue = nums[i - 1] + nums[i] + nums[i + 1];
                selectIndex = i;
                if (maxValue == 3) break;
            }
        }
        var selectK = 0;
        var res = 0;

        if (nums[selectIndex] == 1)
        {
            selectK = 1;
            nums[selectIndex] = 0;
        }

        while (selectK < k)
        {
            if (maxChanges < 0) return -1;
            if (selectIndex - 1 >= 0 && nums[selectIndex - 1] == 1)
            {
                nums[selectIndex - 1] = 0;
                selectK++;
                res++;
            }
            else if (selectIndex + 1 < nums.Length && nums[selectIndex + 1] == 1)
            {
                nums[selectIndex + 1] = 0;
                selectK++;
                res++;
            }
            else
            {
                if (selectIndex - 1 >= 0)
                    nums[selectIndex - 1] = 1;
                else
                    nums[selectIndex + 1] = 1;
                maxChanges--;
                res++;
            }

        }
        return res;
    }
}