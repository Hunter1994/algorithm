using System.Text;

Trie trie = new Trie();
trie.Add("hello");
trie.Add("he");
trie.Add("hi");
trie.Add("abc");
var res = trie.StartsWith("j");
foreach (var item in res)
{
    Console.WriteLine(item);
}
public class Trie
{
    private Node _head;
    public Trie()
    {
        _head = new Node(' ');
    }

    public void Add(string str)
    {
        var p = _head;
        foreach (var item in str)
        {
            var index = (int)item - 97;
            if (p.Nexts[index] == null)
            {
                var node = new Node(item);
                p.Nexts[index] = node;
            }
            p = p.Nexts[index];
        }
        p.IsEnd = true;
    }
    public IEnumerable<string> StartsWith(string condition)
    {
        var p = _head;
        foreach (var item in condition)
        {
            var index = (int)item - 97;
            if (p.Nexts[index] == null)
            {
                return new List<string>();
            }
            p = p.Nexts[index];
        }
        List<string> res = new();
        if (p.IsEnd)
        {
            res.Add(condition);
        }

        GetSubs(p, condition, res);
        return res;
    }

    private void GetSubs(Node node, string str, List<string> list)
    {
        foreach (var item in node.Nexts)
        {
            if (item != null)
            {
                var newStr = str + item.Data.ToString();
                if (item.IsEnd)
                {
                    list.Add(newStr);
                }
                GetSubs(item, newStr, list);
            }
        }
    }

}

public class Node
{
    public Node[] Nexts { get; set; }
    public char Data { get; set; }
    public bool IsEnd { get; set; }
    public Node(char data)
    {
        this.Data = data;
        Nexts = new Node[26];
    }
}