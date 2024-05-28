// See https://aka.ms/new-console-template for more information

//环检测
// HoopValid.Run();

//两个有序的链表合并
// MergeSortLinked.Run();

//删除最后n个节点
// DeleteLastN.Run(5);

//求链表的中间结点
// MiddleNode.Run();

public class MiddleNode
{
    public static int?[] Run()
    {
        var n1 = new Node(1, null);
        var n2 = new Node(2, n1);
        var n3 = new Node(30, n2);
        var n4 = new Node(40, n3);
        // var n5 = new Node(50, n4);

        var middleValue = 4 / 2;
        var isdouble = true;
        if (!isdouble)
        {
            middleValue++;
        }
        int?[] data = new int?[2];
        var current = 1;
        var p = n4;
        while (p != null)
        {
            if (current == middleValue)
            {
                data[0] = p.Value;
                if (isdouble)
                    data[1] = p.Next.Value;
                break;
            }
            p = p.Next;
            current++;
        }
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(data[i] + " ");
        }
        Console.WriteLine();
        return data;
    }

}

public class DeleteLastN
{
    private static Node head;
    public static void Run(int n)
    {
        var n1 = new Node(1, null);
        var n2 = new Node(2, n1);
        var n3 = new Node(30, n2);
        var n4 = new Node(40, n3);
        var n5 = new Node(50, n4);
        head = n5;

        if (n == 1)
        {
            head = head.Next;
        }
        else
        {
            int current = 2;
            var p = head.Next;
            var pro = head;
            while (p != null)
            {
                if (current == n)
                {
                    pro.Next = p.Next;
                    break;
                }
                pro = p;
                p = p.Next;
                current++;
            }
        }

        var pp = head;
        while (pp != null)
        {
            Console.Write(pp.Value + " ");
            pp = pp.Next;
        }
        Console.WriteLine();
    }
}


public class MergeSortLinked
{
    public static void Run()
    {
        var n1 = new Node(1, null);
        var n2 = new Node(2, n1);
        var n3 = new Node(30, n2);
        var n4 = new Node(40, n3);
        var n5 = new Node(50, n4);

        var k1 = new Node(1, null);
        var k2 = new Node(5, k1);
        var k3 = new Node(34, k2);
        var k4 = new Node(60, k3);
        var k5 = new Node(70, k4);

        var n = new Node(0, null);
        var p = n;
        var p1 = n5;//可以调整
        var p2 = k5;//可以调整
        while (p1 != null && p2 != null)
        {
            if (p1.Value > p2.Value)
            {
                p.Next = p1;
                p1 = p1.Next;
            }
            else
            {
                p.Next = p2;
                p2 = p2.Next;
            }
            p = p.Next;
        }

        while (p1 != null)
        {
            p.Next = p1;
            p1 = p1.Next;
            p = p.Next;
        }
        while (p2 != null)
        {
            p.Next = p2;
            p2 = p2.Next;
            p = p.Next;
        }

        p = n.Next;
        while (p != null)
        {
            Console.Write(p.Value + " ");
            p = p.Next;
        }
        Console.WriteLine();

    }
}


public class HoopValid
{
    public static void Run()
    {
        var n1 = new Node(1, null);
        var n2 = new Node(2, n1);
        var n3 = new Node(3, n2);
        var n4 = new Node(4, n3);
        var n5 = new Node(5, n4);
        n4.Next = n5;
        Console.WriteLine(Valid(n5));
    }

    static bool Valid(Node node)
    {
        var p1 = node;
        var p2 = p1.Next;
        while (p1 != null && p2 != null && p2.Next != null)
        {
            if (p1 == p2)
            { return true; }
            p1 = p1.Next;
            p2 = p2.Next.Next;
        }
        return false;
    }
}
public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node(int value, Node next)
    {
        Value = value;
        Next = next;
    }
}