// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Graph g = new Graph(8);
g.Add(0, 1);
g.Add(0, 3);
g.Add(1, 2);
g.Add(1, 4);
g.Add(2, 5);
g.Add(3, 4);
g.Add(4, 5);
g.Add(4, 6);
g.Add(5, 7);
g.Add(6, 7);
g.Dfs(0, 6);

public class Graph
{//邻接表
    public int v;
    public LinkedList<int>[] adj;
    public Graph(int v)
    {
        this.v = v;
        adj = new LinkedList<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new LinkedList<int>();
        }
    }
    public void Add(int i, int j)
    {
        adj[i].AddLast(j);
        adj[j].AddLast(i);
    }

    bool found = false;
    public void Dfs(int i, int j)
    {
        bool[] b = new bool[v];
        int[] prev = new int[v];
        for (int k = 0; k < v; k++)
        {
            prev[k] = -1;
        }
        b[i] = true;
        Dfs(prev, b, i, j);
        print(prev, j);

    }
    public void Dfs(int[] prev, bool[] b, int i, int j)
    {
        if (found) return;
        b[i] = true;
        if (i == j)
        {
            found = true;
            return;
        }
        foreach (int k in adj[i])
        {
            if (!b[k])
            {
                prev[k] = i;
                Dfs(prev, b, k, j);
            }
        }
    }

    public void bfs(int i, int j)
    {
        bool[] b = new bool[v];
        Queue<int> q = new Queue<int>();
        int[] prev = new int[v];
        for (int k = 0; k < v; k++)
        {
            prev[k] = -1;
        }

        b[i] = true;
        q.Enqueue(i);

        while (q.Count > 0)
        {
            var item = q.Dequeue();
            foreach (int k in adj[item])
            {
                if (!b[k])
                {
                    prev[k] = item;
                    if (k == j)
                    {
                        print(prev, k);
                        return;
                    }
                    q.Enqueue(k);
                    b[k] = true;
                }

            }
        }
    }

    void print(int[] prev, int value)
    {
        if (prev == null || value == -1) return;
        print(prev, prev[value]);
        Console.Write(value + " ");
    }

    public void Show()
    {
        for (int i = 0; i < v; i++)
        {
            Console.Write(i + ": ");
            foreach (int j in adj[i])
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}