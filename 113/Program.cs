
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
    public int MaxDepth(TreeNode root)
    {
        int level = 0;
        if (root == null) return level;
        level++;
        Queue<(TreeNode, int)> queue = new();
        queue.Enqueue((root, 1));
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (level < node.Item2) level = node.Item2;
            if (node.Item1.left != null)
                queue.Enqueue((node.Item1.left, node.Item2 + 1));

            if (node.Item1.right != null)
                queue.Enqueue((node.Item1.right, node.Item2 + 1));

        }

        return level;

    }
}