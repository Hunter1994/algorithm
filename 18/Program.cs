// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<string> str = new List<string>() { "abce", "bcd", "ce" };

Trie t = new Trie();
foreach (var item in str)
{
    t.Insert(item);
}

t.buildFailurePointer();
t.match("abce");
Console.WriteLine(t.Find("abce"));


public class Trie
{
    public Node Root = new Node('/');
    public void Insert(string str)
    {
        var p = Root;
        for (int i = 0; i < str.Length; i++)
        {
            if (p.Nodes == null)
            {
                p.Nodes = new Node[26];
            }
            if (p.Nodes[(int)str[i] - (int)'a'] == null)
            {
                p.Nodes[(int)str[i] - (int)'a'] = new Node(str[i]);
            }
            p = p.Nodes[(int)str[i] - (int)'a'];
        }
        p.Length = str.Length;
        p.IsEndingChar = true;
    }

    public bool Find(string str)
    {
        var p = Root;
        for (int i = 0; i < str.Length; i++)
        {
            if (p.Nodes == null) return false;
            if (p.Nodes[(int)str[i] - (int)'a'] == null) return false;
            p = p.Nodes[(int)str[i] - (int)'a'];
        }
        if (p.IsEndingChar) return true;
        else return false;
    }
    public void buildFailurePointer()
    {
        Queue<Node> queue = new Queue<Node>();
        Root.Fail = null;
        queue.Enqueue(Root);
        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            for (int i = 0; i < 26; i++)
            {
                var pc = p.Nodes[i];
                if (pc == null) continue;
                if (p == Root)
                {
                    pc.Fail = Root;
                }
                var q = p.Fail;
                while (q != null)
                {
                    var qc = q.Nodes[(int)pc.Data - (int)'a'];
                    if (qc != null)
                    {
                        pc.Fail = qc;
                        break;
                    }
                    q = q.Fail;
                }
                if (q == null)
                {
                    pc.Fail = Root;
                }
                queue.Enqueue(pc);
            }

        }
    }
    public void match(string str)
    {
        var p = Root;
        for (int i = 0; i < str.Length; i++)
        {
            var idx = (int)str[i] - (int)'a';
            while (p.Nodes[idx] == null && p != Root)
            {
                p = p.Fail;
            }
            if (p.Nodes[idx] == null) p = Root;
            p = p.Nodes[idx];
            var temp = p;
            while (temp != Root)
            {
                if (temp.IsEndingChar)
                {
                    var startIndex = i - temp.Length + 1;
                    Console.WriteLine($"匹配成功:开始索引：{startIndex},长度:{temp.Length} ");
                }
                temp = temp.Fail;
            }
        }

    }
}

public class Node
{
    public char Data { get; set; }
    public Node[] Nodes { get; set; }
    public bool IsEndingChar { get; set; }
    public int Length { get; set; } = -1;
    public Node Fail { get; set; }
    public Node(char data)
    {
        this.Data = data;
        Nodes = new Node[26];
    }
}



