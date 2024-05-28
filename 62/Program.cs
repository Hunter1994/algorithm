
using System.IO;
B b = new B();
await b.RunAsync();

public class B
{
    public async Task RunAsync()
    {
        A a = new A();
        for (int i = 0; i < 10; i++)
        {
            await a.GetAsync(i);
        }
    }
}


public class A
{
    public async Task GetAsync(int i)
    {
        StreamReader sr = new StreamReader(@"D:\src\58\Program.cs");
        await sr.ReadToEndAsync();
        Console.WriteLine(i);
    }

}

// SkipList skipList = new SkipList();
// skipList.insert(1);
// skipList.insert(2);
// skipList.insert(3);
// skipList.insert(5);
// skipList.find(5);

public class SkipList
{
    private static int MAX_LEVEL = 16;
    private int levelCount = 1;
    //带头链表
    private Node head = new Node(MAX_LEVEL);
    private Random r = new Random();
    public Node find(int value)
    {
        Node p = head;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (p.forwards[i] != null && p.forwards[i].data < value)
            {
                p = p.forwards[i];
            }
        }

        if (p.forwards[0] != null && p.forwards[0].data == value)
            return p.forwards[0];
        else
            return null;
    }

    public void insert(int value)
    {
        int level = head.forwards[0] == null ? 1 : randomLevel();
        if (level > levelCount)
        {
            level = ++levelCount;
        }
        Node newNode = new Node(level);
        newNode.data = value;
        var p = head;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (p.forwards[i] != null && p.forwards[i].data < value)
            {
                p = p.forwards[i];
            }
            if (level > i)
            {
                if (p.forwards[i] == null)
                {
                    p.forwards[i] = newNode;
                }
                else
                {
                    Node next = p.forwards[i];
                    p.forwards[i] = newNode;
                    newNode.forwards[i] = next;
                }
            }
        }

    }

    public int randomLevel()
    {
        return r.Next(1, MAX_LEVEL);
    }
}

public class Node
{
    public int data = -1;
    /**
    * 表示当前节点位置的下一个节点所有层的数据，从上层切换到下层，就是数组下标-1，
    * forwards[3]表示当前节点在第三层的下一个节点。
    */
    public Node[] forwards;
    public Node(int level)
    {
        forwards = new Node[level];
    }
}