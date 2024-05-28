// See https://aka.ms/new-console-template for more information

Trie t = new Trie();
// t.Insert("hello".ToArray());
// t.Insert("hi".ToArray());
// t.Insert("aa".ToArray());
t.Insert("abc".ToArray());
t.Insert("bcd".ToArray());
t.BuildFailurePointer();
t.m("abcde".ToArray());
//t.match("hi".ToArray());
Console.WriteLine(t.find("hi".ToArray()));


public class Trie
{
    private TrieNode root = new TrieNode('/');
    public void Insert(char[] text)
    {
        var p = root;
        for (int i = 0; i < text.Length; i++)
        {
            var index = (int)text[i] - (int)'a';
            if (p.Children[index] == null)
            {
                TrieNode node = new TrieNode(text[i]);
                p.Children[index] = node;
            }
            p = p.Children[index];
        }
        p.IsEndingChar = true;
        p.Length = text.Length;
    }

    public void BuildFailurePointer()
    {
        Queue<TrieNode> queue = new Queue<TrieNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            for (int i = 0; i < p.Children.Length; i++)
            {
                var pc = p.Children[i];
                if (pc == null) continue;
                if (p == root)
                {
                    pc.Fail = root;
                }
                else
                {
                    var q = p.Fail;
                    while (q != null)
                    {
                        var qc = q.Children[(int)pc.Data - (int)'a'];
                        if (qc != null)
                        {
                            pc.Fail = qc;
                            break;
                        }
                        q = q.Fail;
                    }
                    if (q == null) pc.Fail = root;
                }
                queue.Enqueue(pc);
            }

        }

    }

    public void match(char[] text)
    {
        var p = root;
        for (int i = 0; i < text.Length; i++)
        {
            var idx = (int)text[i] - (int)'a';
            while (p.Children[idx] == null && p != root)
            {
                p = p.Fail;
            }
            p = p.Children[idx];
            if (p == null) p = root;
            var temp = p;
            while (temp != root)
            {
                if (temp.IsEndingChar)
                {
                    var start = i - temp.Length + 1;
                    Console.WriteLine($"({start},{start + temp.Length - 1})");
                }
                temp = temp.Fail;
            }

        }
    }

    public bool find(char[] text)
    {
        var p = root;
        for (int i = 0; i < text.Length; i++)
        {
            var index = (int)text[i] - (int)'a';
            if (p.Children[index] == null) return false;
            p = p.Children[index];
        }
        return p.IsEndingChar;

    }

    public void m(char[] text)
    {
        var p = root;
        for (int i = 0; i < text.Length; i++)
        {
            var idx = (int)text[i] - (int)'a';
            while (p.Children[idx] == null && p != root)
            {
                p = p.Fail;
            }
            p = p.Children[idx];
            if (p == null) p = root;
            var temp = p;
            while (temp != root)
            {
                if (temp.IsEndingChar)
                {
                    var start = i - temp.Length + 1;
                    Console.WriteLine($"({start},{start + temp.Length - 1})");
                }
                temp = temp.Fail;
            }
        }
    }

}


public class TrieNode
{
    public char Data { get; set; }
    public TrieNode[] Children { get; set; }
    public bool IsEndingChar { get; set; }
    public int Length { get; set; } = -1;
    public TrieNode Fail { get; set; }
    public TrieNode(char data)
    {
        Children = new TrieNode[26];
        Data = data;
    }
}


