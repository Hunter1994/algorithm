// See https://aka.ms/new-console-template for more information

int[] nums = { 2, 9, 3, 6, 5, 1, 7 };
var l = LongestIncreasingSubsequence2(nums);
Console.WriteLine(l);

int LongestIncreasingSubsequence2(int[] nums)
{
    int n = nums.Length;
    if (n == 0) return 0;

    int[] dp = new int[n]; // dp[i] 表示以第 i 个数字结尾的最长递增子序列的长度  
    int maxLen = 1; // 最长递增子序列的长度  
    dp[0] = 1;
    for (int i = 1; i < n; i++)
    {
        dp[i] = 1; // 初始化 dp[i] 为 1，表示以第 i 个数字结尾的最长递增子序列长度为 1  

        for (int j = 0; j < i; j++)
        {
            if (nums[i] > nums[j])
            {
                dp[i] = Math.Max(dp[i], dp[j] + 1); // 将第 i 个数字添加到以第 j 个数字结尾的最长递增子序列中  
            }
        }

        maxLen = Math.Max(maxLen, dp[i]); // 更新最长递增子序列的长度  
    }

    return maxLen;
}
int LongestIncreasingSubsequence(int[] nums)
{
    int n = nums.Length;
    if (n == 0) return 0;

    int[] dp = new int[n]; // dp[i] 表示以第 i 个数字结尾的最长递增子序列的长度  
    dp[0] = 1;

    int maxLen = 1; // 最长递增子序列的长度  
    for (int i = 1; i < n; i++)
    {
        dp[i] = 1;
        for (int j = i - 1; j >= 0; j--)
        {
            if (nums[j] < nums[i])
            {
                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }

        maxLen = Math.Max(maxLen, dp[i]); // 更新最长递增子序列的长度  
    }

    return maxLen;
}
int lengthOfLIS(int[] nums)
{
    if (nums.Length == 0)
    {
        return 0;
    }
    int[] dp = new int[nums.Length];
    dp[0] = 1;
    int maxans = 1;
    for (int i = 1; i < nums.Length; i++)
    {
        dp[i] = 1;
        for (int j = 0; j < i; j++)
        {
            if (nums[i] > nums[j])
            {
                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
        maxans = Math.Max(maxans, dp[i]);
    }
    return maxans;
}

