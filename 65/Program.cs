// See https://aka.ms/new-console-template for more information

SearchTree st = new SearchTree();
// st.Add(40);
// st.Add(3);
// st.Add(41);
// st.Add(4);
// st.Add(1);
st.Add(5);
st.Delete(5);
var a1 = st.Exists(5);
var a2 = st.Exists(6);
var a = st.Head;
Console.WriteLine(a.ToString());

public class SearchTree
{
    public Node Head { get; set; }

    public void Add(int i)
    {
        if (Head == null)
        {
            Head = new Node(i);
            return;
        }

        var p = Head;
        while (p != null)
        {
            if (i >= p.Data)
            {
                if (p.Right == null)
                {
                    p.Right = new Node(i);
                    return;
                }
                else
                    p = p.Right;
            }
            else
            {
                if (p.Left == null)
                {
                    p.Left = new Node(i);
                    return;
                }
                else
                    p = p.Left;
            }
        }
    }
    public bool Exists(int i)
    {
        if (Head == null) return false;
        var p = Head;
        while (p != null)
        {
            if (i > p.Data)
            {
                p = p.Right;
            }
            else if (i < p.Data)
            {
                p = p.Left;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public void Delete(int i)
    {
        var p = Head;
        Node pp = null;
        while (p != null && p.Data != i)
        {
            pp = p;
            if (i > p.Data) p = p.Right;
            else p = p.Left;
        }
        if (p == null) return;

        if (p.Left != null && p.Right != null)
        {
            var minpp = p;
            var minp = p.Right;
            if (minp != null && minp.Left != null)
            {
                minpp = minp;
                minp = minp.Left;
            }
            p.Data = minp.Data;
            p = minp;
            pp = minpp;
        }

        Node child;
        if (p.Left != null) child = p.Left;
        else if (p.Right != null) child = p.Right;
        else child = null;

        if (pp == null) Head = child;
        else if (pp.Left == p) pp.Left = child;
        else pp.Right = child;
    }









    public void delete(int data)
    {
        Node p = Head; // p指向要删除的节点，初始化指向根节点
        Node pp = null; // pp记录的是p的父节点
        while (p != null && p.Data != data)
        {
            pp = p;
            if (data > p.Data) p = p.Right;
            else p = p.Left;
        }
        if (p == null) return; // 没有找到

        // 要删除的节点有两个子节点
        if (p.Left != null && p.Right != null)
        { // 查找右子树中最小节点
            Node minP = p.Right;
            Node minPP = p; // minPP表示minP的父节点
            while (minP.Left != null)
            {
                minPP = minP;
                minP = minP.Left;
            }
            p.Data = minP.Data; // 将minP的数据替换到p中
            p = minP; // 下面就变成了删除minP了
            pp = minPP;
        }

        // 删除节点是叶子节点或者仅有一个子节点
        Node child; // p的子节点
        if (p.Left != null) child = p.Left;
        else if (p.Right != null) child = p.Right;
        else child = null;

        if (pp == null) Head = child; // 删除的是根节点
        else if (pp.Left == p) pp.Left = child;
        else pp.Right = child;
    }

}

public class Node
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(int data)
    {
        Data = data;
    }
}