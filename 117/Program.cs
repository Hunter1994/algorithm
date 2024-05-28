
Griph griph = new(8);
griph.Add(0, 1);
griph.Add(0, 3);
griph.Add(1, 4);
griph.Add(3, 4);
griph.Add(1, 2);
griph.Add(2, 5);
griph.Add(4, 5);
griph.Add(4, 6);
griph.Add(5, 7);
griph.Add(6, 7);
griph.DFS(0, 6);


public class Griph
{
    private LinkedList<int>[] adj;
    private int _v;
    public Griph(int v)
    {
        adj = new LinkedList<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new LinkedList<int>();
        }
        _v = v;
    }
    public void Add(int s, int t)
    {
        adj[s].AddLast(t);
        adj[t].AddLast(s);
    }
    public void DFS(int s, int t)
    {
        bool[] visited = new bool[_v];
        int[] prev = new int[_v];
        for (int i = 0; i < _v; i++)
        {
            prev[i] = -1;
        }
        visited[s] = true;
        DFS(visited, prev, s, t);
        Print(prev, t);
        Console.WriteLine();

    }
    private bool found = false;
    void DFS(bool[] visited, int[] prev, int d, int t)
    {
        if (found) return;
        foreach (var item in adj[d])
        {
            if (!visited[item])
            {
                visited[item] = true;
                prev[item] = d;
                if (d == t)
                {
                    found = true;
                    return;
                }
                DFS(visited, prev, item, t);
            }
        }
    }



    public void BFS(int s, int t)
    {
        Queue<int> queue = new();
        bool[] visited = new bool[_v];
        int[] prev = new int[_v];
        for (int i = 0; i < _v; i++)
        {
            prev[i] = -1;
        }

        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            foreach (var item in adj[node])
            {
                if (!visited[item])
                {
                    prev[item] = node;
                    visited[item] = true;
                    if (item == t) break;
                    queue.Enqueue(item);
                }
            }
        }

        Print(prev, t);
        Console.WriteLine();
    }

    void Print(int[] prev, int t)
    {
        if (t == -1) return;
        Print(prev, prev[t]);
        Console.Write(t + " ");
    }


}