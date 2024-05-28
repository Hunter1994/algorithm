// See https://aka.ms/new-console-template for more information
IQueue q = new LinkedQueue(3);
q.Enqueue(1);
q.Enqueue(2);
Console.WriteLine(q.Dequeue());
q.Enqueue(3);
Console.WriteLine(q.Dequeue());
q.Enqueue(4);
Console.WriteLine(q.Dequeue());
Console.WriteLine(q.Dequeue());
public interface IQueue
{
    int Count { get; }
    void Enqueue(int i);
    int Dequeue();
}

public class LinkedQueue : IQueue
{
    public int Count { get; set; }
    private Node _head;
    private Node _tail;
    public LinkedQueue(int n)
    {
        _head = new Node(-1);
        _tail = _head;
    }


    public int Dequeue()
    {
        if (Count == 0)
            throw new Exception();

        var data = _head.Next.Data;
        _head.Next = _head.Next.Next;
        Count--;
        return data;
    }

    public void Enqueue(int i)
    {
        _tail.Next = new Node(i);
        _tail = _tail.Next;
        Count++;
    }
    public class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }
        public Node(int data)
        {
            this.Data = data;
        }
    }
}

public class ArrayQueue : IQueue
{
    public int Count { get; set; }
    private int n;
    private int[] arr;
    private int head;
    private int tail;
    public ArrayQueue(int n)
    {
        arr = new int[n];
        this.n = n;
    }
    public int Dequeue()
    {
        if (head % n == tail) throw new Exception();
        var data = arr[head];
        head = (head + 1) % n;
        Count--;
        return data;
    }

    public void Enqueue(int i)
    {
        if ((tail + 1) % n == head) throw new Exception();
        arr[tail] = i;
        tail = (tail + 1) % n;
        Count++;
    }
}
