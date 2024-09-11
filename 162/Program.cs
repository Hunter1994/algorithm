// return;
MagicDictionary magicDictionary = new MagicDictionary();

magicDictionary.BuildDict(["hel", "hal"]);
var res = magicDictionary.Search("hel");
Console.WriteLine(res);
public class MagicDictionary
{
    private Tree root;
    public MagicDictionary()
    {
        root = new Tree();
    }

    public void BuildDict(string[] dictionary)
    {
        foreach (var str in dictionary)
        {
            var cur = root;
            foreach (var item in str)
            {
                var index = (int)item - 65;
                if (cur.next[index] == null)
                {
                    cur.next[index] = new Tree(item);
                }
                cur = cur.next[index];
            }
            cur.end = true;
        }
    }

    public bool Search(string searchWord)
    {
        return Find(root, 0, searchWord, 0);
    }
    bool Find(Tree node, int index, string searchWord, int err)
    {
        if (index == searchWord.Length)
        {
            return node.end && err == 1;
        }

        var idx = (int)searchWord[index] - 65;
        var t = node.next[idx];

        if (t != null)
        {
            var a = Find(t, index + 1, searchWord, err);
            if (a) return a;
        }
        if (err < 1)
        {
            for (int i = 0; i < node.next.Length; i++)
            {
                if (node.next[i] != null && i != idx)
                {
                    if (Find(node.next[i], index + 1, searchWord, err + 1)) return true;
                }
            }
        }
        return false;
    }
    public class Tree
    {
        public char data;
        public Tree[] next;
        public bool end;
        public Tree()
        {
            next = new Tree[58];
        }
        public Tree(char data)
        {
            this.data = data;
            next = new Tree[58];
        }

    }
}



/**
 * Your MagicDictionary object will be instantiated and called as such:
 * MagicDictionary obj = new MagicDictionary();
 * obj.BuildDict(dictionary);
 * bool param_2 = obj.Search(searchWord);
 */