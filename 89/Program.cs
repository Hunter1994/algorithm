// See https://aka.ms/new-console-template for more information
using System.Globalization;



SingleLinked<int> linked = new SingleLinked<int>();
linked.Add(1);
linked.Add(2);
linked.Add(4);
linked.Add(8);
linked.Print();
// linked.Reversal();
// linked.Print();
linked.MiddleNode();

SingleLinked<int> linked2 = new SingleLinked<int>();
linked2.Add(1);
linked2.Add(4);
linked2.Add(5);
linked2.Add(9);
linked2.Print();


linked2.merge(linked.Head.Next, linked2.Head.Next);


public class SingleLinked<T> : ILinked<T> where T : IComparable<T>
{
    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }
    public int Count { get; set; }
    public SingleLinked()
    {
        var root = new Node<T>(default(T));
        Head = root;
        Tail = root;
        Count = 0;
    }
    public void Add(T data)
    {
        var node = new Node<T>(data);
        Tail.Next = node;
        Tail = node;
        Count++;
    }

    public void Delete(T data)
    {
        var pp = Head;
        var p = Head.Next;
        while (p != null)
        {
            var a = p.Data.CompareTo(data);
            if (p.Data.CompareTo(data) == 0)
            {
                break;
            }
            pp = p;
            p = p.Next;
        }
        if (p != null)
        {
            pp.Next = p.Next;
        }
        Count--;
    }

    public void Reversal()
    {
        Tail = Reversal(Head.Next);
        Tail.Next = null;
    }

    private Node<T> Reversal(Node<T> n)
    {
        if (n == null) return null;
        var next = Reversal(n.Next);
        if (next != null)
        {
            next.Next = n;
        }
        else
        {
            Head.Next = n;
        }
        return n;
    }


    public void Print()
    {
        var p = Head.Next;
        while (p != null)
        {
            Console.Write(p.Data + " ");
            p = p.Next;
        }
        Console.WriteLine();
    }

    public void MiddleNode()
    {
        var ms = new List<int>(2);
        var m = Count / 2;
        ms.Add(m);
        var d = Count % 2 == 0;
        if (d)
            ms.Add(m - 1);
        var p = Head.Next;
        var index = 0;
        while (p != null)
        {
            if (index > m) return;

            if (ms.Contains(index))
            {
                Console.WriteLine(p.Data);
            }
            index++;
            p = p.Next;
        }


    }

    public void merge(Node<T> n1, Node<T> n2)
    {
        var p = new Node<T>(default(T));
        var ptail = p;

        var i = n1;
        var j = n2;
        while (i != null && j != null)
        {
            if (i.Data.CompareTo(j.Data) == -1)
            {
                ptail.Next = i;
                ptail = i;
                i = i.Next;
            }
            else
            {
                ptail.Next = j;
                ptail = j;
                j = j.Next;
            }
        }
        while (i != null)
        {
            ptail.Next = i;
            ptail = i;
            i = i.Next;
        }
        while (j != null)
        {
            ptail.Next = j;
            ptail = j;
            j = j.Next;
        }

        var h = p.Next;
        while (h != null)
        {
            Console.Write(h.Data + " ");
            h = h.Next;
        }
        Console.WriteLine();


    }
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            this.Data = data;
        }
    }
}

public class LoopLinked<T> : ILinked<T> where T : IComparable<T>
{
    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }
    public int Count { get; set; }
    public LoopLinked()
    {
        var root = new Node<T>(default(T));
        Head = root;
        Tail = root;
        Count = 0;
    }
    public void Add(T data)
    {
        var node = new Node<T>(data);
        Tail.Next = node;
        Tail = node;
        Tail.Next = Head;
        Count++;
    }

    public void Delete(T data)
    {
        var pp = Head;
        var p = Head.Next;
        while (p != Head)
        {
            var a = p.Data.CompareTo(data);
            if (p.Data.CompareTo(data) == 0)
            {
                break;
            }
            pp = p;
            p = p.Next;
        }
        if (p != Head)
        {
            pp.Next = p.Next;
        }
        Count--;
    }

    public void Print()
    {
        var p = Head.Next;
        while (p != Head)
        {
            Console.Write(p.Data + " ");
            p = p.Next;
        }
        Console.WriteLine();
    }

    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            this.Data = data;
        }
    }
}

public class DoubleLinked<T> : ILinked<T> where T : IComparable<T>
{
    public Node<T> Head { get; set; }
    public Node<T> Tail { get; set; }
    public int Count { get; set; }
    public DoubleLinked()
    {
        var root = new Node<T>(default(T));
        Head = root;
        Tail = root;
        Count = 0;
    }
    public void Add(T data)
    {
        var node = new Node<T>(data);
        Tail.Next = node;
        Tail = node;
        Tail.Next = Head;
        Count++;
    }

    public void Delete(T data)
    {
        var pp = Head;
        var p = Head.Next;
        while (p != Head)
        {
            var a = p.Data.CompareTo(data);
            if (p.Data.CompareTo(data) == 0)
            {
                break;
            }
            pp = p;
            p = p.Next;
        }
        if (p != Head)
        {
            pp.Next = p.Next;
        }
        Count--;
    }

    public void Print()
    {
        var p = Head.Next;
        while (p != Head)
        {
            Console.Write(p.Data + " ");
            p = p.Next;
        }
        Console.WriteLine();
    }

    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node(T data)
        {
            this.Data = data;
        }
    }
}
public interface ILinked<T> where T : IComparable<T>
{
    void Delete(T data);
    void Add(T data);
    void Print();
}