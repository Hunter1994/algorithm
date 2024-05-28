// See https://aka.ms/new-console-template for more information


LinkedList ll = new LinkedList();
ll.Add(1);
ll.Add(2);
ll.Add(3);
ll.Add(4);
ll.Add(5);
ll.Remove(1);
ll.Add(0);

ll.Print();

public class LinkedList
{
    private Node head;
    public LinkedList()
    {
        head = new Node(0, null);
    }
    public void Add(int i)
    {
        var p = head.Next;
        Node pre = head;
        while (p != null)
        {
            pre = p;
            p = p.Next;
        }
        pre.Next = new Node(i, null);
    }
    public void Remove(int i)
    {
        var p = head.Next;
        Node pre = head;
        while (p != null)
        {
            if (p.Value == i)
            {
                break;
            }
            pre = p;
            p = p.Next;
        }
        pre.Next = p.Next;
    }
    public void Print()
    {
        var p = head.Next;
        while (p != null)
        {
            Console.Write(p.Value + " ");
            p = p.Next;
        }
        System.Console.WriteLine();
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
