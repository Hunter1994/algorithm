Browser browser = new Browser(new LinkedStack(5), new LinkedStack(5));
browser.Open(1);
browser.Open(2);
browser.Open(3);
browser.Return();
browser.Return();
browser.Return();
browser.Next();
browser.Next();
browser.Next();




// IStack s = new LinkedStack(5);
// s.Push(1);
// s.Push(2);
// s.Push(3);
// Console.WriteLine(s.Pop());
// Console.WriteLine(s.Pop());
// Console.WriteLine(s.Pop());
public interface IStack
{
    int count { get; }
    void Push(int i);
    int Pop();
}

public class Browser
{
    private IStack _historyStack;
    private IStack _returnStack;
    public Browser(IStack historyStack, IStack returnStack)
    {
        _historyStack = historyStack;
        _returnStack = returnStack;
    }
    public void Open(int i)
    {
        Console.WriteLine("打开页面：" + i);
        _historyStack.Push(i);
    }
    public void Next()
    {
        if (_returnStack.count == 0)
        {
            Console.WriteLine("前进没内容了!");
            return;
        }
        var data = _returnStack.Pop();
        _historyStack.Push(data);
        Console.WriteLine("前进页面：" + data);
    }
    public void Return()
    {
        if (_historyStack.count == 1)
        {
            Console.WriteLine("后退没内容了!");
            return;
        }
        var data = _historyStack.Pop();
        _returnStack.Push(data);
        Console.WriteLine("退出页面：" + data);
    }
}

public class LinkedStack : IStack
{
    private Node head;
    public int count { get; set; }
    public LinkedStack(int n)
    {
    }
    public void Push(int i)
    {
        Node node = new Node(i);
        node.Next = head;
        head = node;
        count++;
    }
    public int Pop()
    {
        if (head == null) throw new Exception();
        var data = head.Data;
        head = head.Next;
        count--;
        return data;
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
public class ArrayStack : IStack
{
    private int[] arr;
    public int count { get; set; }
    private int n;
    public ArrayStack(int n)
    {
        arr = new int[n];
        this.n = n;
    }
    public void Push(int i)
    {
        if (count == n) return;
        arr[count++] = i;
    }
    public int Pop()
    {
        if (count == 0) throw new Exception();
        return arr[--count];
    }
}
