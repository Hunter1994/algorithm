TreeNode t1 = new(5);
TreeNode t2 = new(4);
TreeNode t3 = new(8);
TreeNode t4 = new(11);
TreeNode t5 = new(7);
TreeNode t6 = new(2);
TreeNode t7 = new(13);
TreeNode t8 = new(4);
TreeNode t9 = new(1);

t1.left = t2;
t1.right = t3;

t2.left = t4;

t4.left = t5;
t4.right = t6;

t3.left = t7;
t3.right = t8;

t8.right = t9;


Solution solution = new();
var res = solution.HasPathSum(t1, 22);
Console.WriteLine(res);
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        return HasPathSum(root, 0, targetSum);
    }
    public bool HasPathSum(TreeNode root, int currentSum, int targetSum)
    {
        if (root == null) return false;
        var sum = root.val + currentSum;
        if (sum == targetSum && root.left == null && root.right == null) return true;
        return HasPathSum(root.left, sum, targetSum) ||
         HasPathSum(root.right, sum, targetSum);
    }
}