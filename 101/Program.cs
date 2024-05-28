
LRU lru = new(3);
lru.Find(1);
lru.Find(2);
lru.Find(3);
lru.Find(1);
lru.Find(4);

Console.WriteLine();


public class LRU
{
    private int _count;
    private int _index;
    private Node _head;
    private Node _tail;
    public LRU(int n)
    {
        _count = n;
        _index = 0;
        Node root = new(-1);
        _head = root;
        _tail = root;
    }

    public void Find(int data)
    {
        var p = _head.Next;
        Node pp = _head;
        while (p != null)
        {
            if (p.Data == data)
            {
                break;
            }
            pp = p;
            p = p.Next;
        }

        if (p == null)
        {
            Node n = new(data);
            _tail.Next = n;
            _tail = n;
            _index++;
        }
        else if (p != _tail)
        {
            pp.Next = pp.Next.Next;
            _tail.Next = p;
            _tail = p;
            _tail.Next = null;
        }

        if (_index > _count)
        {
            _head.Next = _head.Next.Next;
            _index--;
        }
    }


    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node(int data)
        {
            this.Data = data;
        }
    }
}