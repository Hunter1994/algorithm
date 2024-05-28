// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
BaseLru l = new Lru(5);
l.Add(1);
l.Add(2);
l.Add(3);
l.Add(4);
l.Add(5);
l.Add(1);
l.Add(6);

l.Show();
l = new LruArray(5);
l.Add(1);
l.Add(2);
l.Add(3);
l.Add(4);
l.Add(5);
l.Add(1);
l.Add(6);

l.Show();


Node node1 = new Node(1, null);
Node node2 = new Node(2, node1);
Node node3 = new Node(3, node2);
Node node4 = new Node(4, node3);

var n = node4;
while (n != null)
{
    Console.Write(n.Value + " ");
    n = n.Next;
}
Console.WriteLine();

public interface BaseLru
{
    void Add(int v);
    void Show();
}

public class LruArray : BaseLru
{
    private int[] arr;
    private int maxCount;
    private int count;
    public LruArray(int max)
    {
        maxCount = max;
        arr = new int[maxCount];
    }
    public void Add(int v)
    {
        int moveEndIndex = count - 1;
        bool isadd = true;
        for (int i = 0; i < count - 1; i++)
        {
            if (arr[i] == v)
            {
                moveEndIndex = i;
                isadd = false;
                break;
            }
        }

        for (int j = moveEndIndex; j > 0; j--)
        {
            arr[j] = arr[j - 1];
        }
        arr[0] = v;
        if (isadd && count < maxCount) count++;
    }
    public void Show()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}


public class Lru : BaseLru
{
    private Node head;

    private int maxCount;
    private int count;
    public Lru(int max)
    {
        maxCount = max;
    }
    public void Add(int v)
    {

        if (head == null)
        {
            head = new Node()
            {
                Value = v
            };
            count++;
        }
        else
        {
            if (head.Value == v) return;

            var node = head.Next;
            var pre = head;
            while (node != null)
            {
                if (node.Value == v)
                {
                    break;
                }
                pre = node;
                node = node.Next;
            }

            if (node != null)
            {
                node.Next = head;
                pre.Next = null;
                head = node;
            }
            else
            {
                if (count == maxCount)
                {
                    node = head.Next;
                    pre = head;
                    while (node != null)
                    {
                        if (node.Next == null)
                        {
                            break;
                        }
                        pre = node;
                        node = node.Next;
                    }
                    pre.Next = null;
                }

                var n = new Node()
                {
                    Value = v
                };
                n.Next = head;
                head = n;
                count++;
            }
        }
    }

    public void Show()
    {
        var node = head;
        while (node != null)
        {
            Console.Write(node.Value + " ");
            node = node.Next;
        }
        Console.WriteLine();
    }

}


public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node(int value, Node next)
    {
        this.Value = value;
        this.Next = next;
    }
    public Node() { }
}