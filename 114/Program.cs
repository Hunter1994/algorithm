
TreeNode ta = new(5);
TreeNode ta2 = new(4);
TreeNode ta3 = new(6);
TreeNode ta4 = new(3);
TreeNode ta5 = new(7);
ta.left = ta2;
ta.right = ta3;
ta3.left = ta4;
ta3.right = ta5;
Solution solution = new Solution();
var ress = solution.IsValidBST(ta);

Console.WriteLine(ress);
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
    public bool IsValidBST(TreeNode root)
    {
        if (root == null) return true;
        return IsValid(root).Item1;
    }

    public bool IsValidBST(TreeNode root, long min, long max)
    {
        if (root == null) return true;
        if (root.val < min || root.val > max)
        {
            return false;
        }

        return IsValidBST(root.left, min, root.val) && IsValidBST(root.right, root.val, max);
    }


    public (bool, int?) IsValidBST2(TreeNode root, int type)
    {
        if (root == null) return (true, null);
        var ldata = IsValidBST2(root.left, 1);
        var rdata = IsValidBST2(root.right, 2);

        if (!ldata.Item1 || !rdata.Item1) return (false, null);

        var res = (root.left == null || root.left.val < root.val) &&
        (root.right == null || root.right.val > root.val);
        if (!res) return (false, null);

        res = (ldata.Item2 == null || ldata.Item2 < root.val) &&
       (rdata.Item2 == null || rdata.Item2 > root.val);
        if (!res) return (false, null);

        var data = root.val;
        if (type == 1)//取最大
        {
            var p = root;
            while (p != null)
            {

            }
            if (root.left != null && root.left.val > data)
            {
                data = root.left.val;
            }
            if (root.right != null && root.right.val > data)
            {
                data = root.right.val;
            }
        }
        if (type == 2)//取最小
        {
            if (root.left != null && root.left.val < data)
            {
                data = root.left.val;
            }
            if (root.right != null && root.right.val < data)
            {
                data = root.right.val;
            }
        }

        return (res, data);
    }

    //(bool, int?（左最大）, int?（右最小）)
    public (bool, int?, int?) IsValid(TreeNode root)
    {
        (bool, int?, int?) lres = (true, null, null);
        (bool, int?, int?) rres = (true, null, null);
        if (root.left != null)
            lres = IsValid(root.left);
        if (root.right != null)
            rres = IsValid(root.right);

        if (!lres.Item1 || !rres.Item1) return (false, null, null);

        var res = (root.left == null || root.left.val < root.val) &&
            (root.right == null || root.right.val > root.val);
        if (!res) return (false, null, null);

        res = (lres.Item2 == null || lres.Item2 < root.val) &&
       (rres.Item3 == null || rres.Item3 > root.val);
        if (!res) return (false, null, null);

        var max = root.val;
        var min = root.val;
        if (lres.Item3 != null && lres.Item3 < root.val)
        {
            min = lres.Item3.Value;
        }
        if (rres.Item2 != null && rres.Item2 > root.val)
        {
            max = rres.Item2.Value;
        }

        return (true, max, min);

    }

}