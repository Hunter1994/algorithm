Griph griph = new(3);
griph.AddAdj(0, 1);
// griph.AddAdj(0, 2);
// griph.AddAdj(1, 2);
griph.dfs();


public class Griph
{
    private LinkedList<int>[] _adj;
    private int _v;

    public Griph(int v)
    {
        this._v = v;
        _adj = new LinkedList<int>[_v];
        for (int i = 0; i < _adj.Length; i++)
        {
            _adj[i] = new LinkedList<int>();
        }
    }
    public void AddAdj(int s, int t)
    {
        _adj[s].AddLast(t);
    }
    public void dfs()
    {
        LinkedList<int>[] inverseAdj = new LinkedList<int>[_v];
        bool[] b = new bool[_v];
        for (int i = 0; i < inverseAdj.Length; i++)
        {
            inverseAdj[i] = new LinkedList<int>();
        }
        for (int i = 0; i < _adj.Length; i++)
        {
            foreach (var item in _adj[i])
            {
                inverseAdj[item].AddLast(i);
            }
        }

        for (int i = 0; i < inverseAdj.Length; i++)
        {
            if (!b[i])
            {
                b[i] = true;
                dfs(inverseAdj, b, i);
            }
        }

    }
    private void dfs(LinkedList<int>[] inverseAdj, bool[] b, int v)
    {
        foreach (var item in inverseAdj[v])
        {
            if (b[item]) continue;
            b[item] = true;
            dfs(inverseAdj, b, item);
        }
        Console.Write("-->" + v);
    }

    public void Kahn()
    {
        Queue<int> queue = new Queue<int>(_v);
        int[] inDegree = new int[_v];
        for (int i = 0; i < _adj.Count(); i++)
        {
            foreach (var item in _adj[i])
            {
                inDegree[item]++;
            }
        }
        for (int i = 0; i < inDegree.Count(); i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count() > 0)
        {
            var q = queue.Dequeue();
            Console.Write("->" + q);
            foreach (var item in _adj[q])
            {
                inDegree[item]--;
                if (inDegree[item] == 0)
                    queue.Enqueue(item);
            }

        }

    }
}