
using System.Net.NetworkInformation;

SearchTree searchTree = new SearchTree();
// Console.WriteLine(searchTree.Find(7));
searchTree.Insert(8);
searchTree.Insert(5);
searchTree.Insert(6);
searchTree.Insert(11);
searchTree.Insert(10);
searchTree.Insert(13);
searchTree.Insert(9);
searchTree.Insert(12);
searchTree.Insert(14);

// Console.WriteLine(searchTree.Next(9));
// Console.WriteLine(searchTree.Prov(14));
searchTree.PrevSort();
searchTree.MiddleSort();
searchTree.NextSort();



// searchTree.Middle();
// searchTree.Delete(8);

// Console.WriteLine(searchTree.Find(7));
// Console.WriteLine(searchTree.Find(0));

// Console.ReadLine();


public class SearchTree
{
    private Node _root;
    private int _count = 0;

    public void PrevSort()
    {
        PrevSort(_root);
        Console.WriteLine();
    }
    private void PrevSort(Node node)
    {
        if (node == null) return;
        Console.Write(node.Data + " ");
        PrevSort(node.Left);
        PrevSort(node.Right);
    }
    public void MiddleSort()
    {
        MiddleSort(_root);
        Console.WriteLine();
    }
    private void MiddleSort(Node node)
    {
        if (node == null) return;
        MiddleSort(node.Left);
        Console.Write(node.Data + " ");
        MiddleSort(node.Right);
    }
    public void NextSort()
    {
        NextSort(_root);
        Console.WriteLine();
    }
    private void NextSort(Node node)
    {
        if (node == null) return;
        NextSort(node.Left);
        NextSort(node.Right);
        Console.Write(node.Data + " ");
    }

    public int Next(int i)
    {
        ParentNode rootNode = new ParentNode(null);
        var tial = rootNode;
        var p = _root;
        while (p != null)
        {
            if (p.Data == i)
            {
                break;
            }
            ParentNode n = new(p);
            n.Prov = tial;
            tial.Next = n;
            tial = n;

            if (p.Data > i)
            {
                p = p.Left;
            }
            else
            {
                p = p.Right;
            }
        }

        if (p == null) return -1;
        if (p.Right != null)
        {
            var r = p.Right;
            while (r.Left != null)
            {
                r = r.Left;
            }
            return r.Data;
        }
        if (tial.Node != null)
        {
            while (tial != null && tial.Node != null)
            {
                if (tial.Node.Data > i)
                {
                    return tial.Node.Data;
                }
                tial = tial.Prov;
            }
        }

        return -1;

    }

    //前驱节点
    public int Prov(int i)
    {
        ParentNode rootNode = new ParentNode(null);
        var tial = rootNode;
        var p = _root;
        while (p != null)
        {
            if (p.Data == i)
            {
                break;
            }
            ParentNode n = new(p);
            n.Prov = tial;
            tial.Next = n;
            tial = n;

            if (p.Data > i)
            {
                p = p.Left;
            }
            else
            {
                p = p.Right;
            }
        }

        if (p == null) return -1;
        if (p.Left != null)
        {
            var r = p.Left;
            while (r.Right != null)
            {
                r = r.Right;
            }
            return r.Data;
        }
        if (tial.Node != null)
        {
            while (tial != null && tial.Node != null)
            {
                if (tial.Node.Data < i)
                {
                    return tial.Node.Data;
                }
                tial = tial.Prov;
            }
        }

        return -1;
    }

    public void Insert(int data)
    {
        var node = new Node(data);
        if (_root == null)
        {
            _root = node;
        }
        else
        {
            var p = _root;
            while (true)
            {
                if (data > p.Data)
                {
                    if (p.Right == null)
                    {
                        p.Right = node;
                        break;
                    }

                    p = p.Right;
                }
                else
                {
                    if (p.Left == null)
                    {
                        p.Left = node;
                        break;
                    }
                    p = p.Left;
                }

            }
        }
        _count++;
    }
    public void Delete(int data)
    {
        var p = _root;
        Node pp = null;
        bool isLeftChild = false;
        while (p != null)
        {
            if (data > p.Data)
            {
                isLeftChild = false;
                pp = p;
                p = p.Right;
            }
            else if (data < p.Data)
            {
                isLeftChild = true;
                pp = p;
                p = p.Left;
            }
            else
            {
                break;
            }

        }
        if (p == null)
        {
            Console.WriteLine("为找到" + data);
            return;
        }
        //删除节点是叶子节点，直接删除
        //删除节点有一个子节点，父节点指向子节点
        //删除节点有两个子节点，将右边的最小节点或者左边的最大节点与当前节点替换，并删除当前节点
        if (p.Left == null && p.Right == null)
        {
            if (p == _root)
            {
                _root = null;
            }
            else if (isLeftChild)
            {
                pp.Left = null;
            }
            else
            {
                pp.Right = null;
            }
        }
        else if (p.Left != null && p.Right != null)
        {
            var rightMinP = p.Right;
            var rightMinPP = rightMinP;

            while (true)
            {
                if (rightMinP.Left == null)
                {
                    break;
                }
                rightMinPP = rightMinP;
                rightMinP = rightMinP.Left;
            }
            rightMinP.Right = p.Right;
            rightMinP.Left = p.Left;
            rightMinPP.Left = null;
            if (pp == null)
            {
                _root = rightMinP;
            }
            else if (isLeftChild)
            {
                pp.Left = rightMinP;
            }
            else
            {
                pp.Right = rightMinP;
            }
        }
        else
        {
            if (isLeftChild)
            {
                pp.Left = null;
            }
            else
            {
                pp.Right = null;
            }


        }
    }
    public int Find(int data)
    {
        var p = _root;
        while (p != null)
        {
            if (data > p.Data)
            {
                p = p.Right;
            }
            else if (data < p.Data)
            {
                p = p.Left;
            }
            else
            {
                break;
            }

        }
        if (p == null) return -1;
        else return p.Data;
    }

}

public class Node
{
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Data { get; set; }
    public Node(int data)
    {
        this.Data = data;
    }
}

public class ParentNode
{
    public ParentNode Next { get; set; }
    public ParentNode Prov { get; set; }
    public Node Node { get; set; }
    public ParentNode(Node node)
    {
        this.Node = node;
    }
}
