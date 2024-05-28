// See https://aka.ms/new-console-template for more information


SkipList skipList = new SkipList();
skipList.Insert(1);
skipList.Insert(2);
skipList.Insert(3);
skipList.Insert(5);
skipList.Insert(4);
skipList.Delete(5);
var res = skipList.Find(4);
if (res != null) Console.WriteLine(res.Data);
else Console.WriteLine("未找到");
public class SkipList
{
    public const int MAXLEVEL = 16;
    private Node head = new Node(MAXLEVEL);
    private int levelCount = 1;
    private Random random = new Random();

    public void Delete(int data)
    {
        var h = head;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (h.Forwards[i] != null && h.Forwards[i].Data < data)
            {
                h = h.Forwards[i];
            }
            if (h.Forwards[i] != null && h.Forwards[i].Data == data)
            {
                h.Forwards[i] = h.Forwards[i].Forwards[i];
            }
        }
    }
    public Node Find(int data)
    {
        var h = head;
        var deleteValue = 0;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (h.Forwards[i] != null && h.Forwards[i].Data < data)
            {
                h = h.Forwards[i];
            }
            if (h.Forwards[0] != null && h.Forwards[0].Data == data)
            {
                return h.Forwards[0];
                deleteValue = 1;
            }
        }
        levelCount = levelCount - deleteValue;
        return null;
    }

    public Node Insert(int data)
    {
        var level = head.Forwards[0] == null ? 1 : random.Next(1, MAXLEVEL);
        if (level > levelCount)
        {
            level = ++levelCount;
        }
        var newNode = new Node(level);
        newNode.Data = data;
        var h = head;
        for (int i = levelCount - 1; i >= 0; i--)
        {
            while (h.Forwards[i] != null && h.Forwards[i].Data < data)
            {
                h = h.Forwards[i];
            }
            if (h.Forwards[i] == null)
            {
                h.Forwards[i] = newNode;
            }
            else
            {
                var nextNode = h.Forwards[i];
                h.Forwards[i] = newNode;
                newNode.Forwards[i] = nextNode;
            }
        }
        return newNode;
    }

}

public class Node
{
    public int Data { get; set; }
    public Node[] Forwards { get; set; }
    public Node(int level)
    {
        Forwards = new Node[level];
    }
}