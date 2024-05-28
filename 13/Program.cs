// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Graph g = new Graph(8);
g.addEdge(0, 1);
g.addEdge(0, 3);
g.addEdge(1, 4);
g.addEdge(1, 2);
g.addEdge(3, 4);
g.addEdge(2, 5);
g.addEdge(4, 5);
g.addEdge(4, 6);
g.addEdge(5, 7);
g.addEdge(6, 7);
g.Show();
g.dfs(0, 6);

public class Graph
{
    private int v;
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

    public void addEdge(int s, int t)
    {
        adj[s].AddLast(t);
        adj[t].AddLast(s);
    }

    public void bfs(int s, int t)
    {
        bool[] visited = new bool[v];
        Queue<int> queue = new Queue<int>();
        int[] prev = new int[v];
        visited[s] = true;
        queue.Enqueue(s);
        for (int i = 0; i < v; i++)
        {
            prev[i] = -1;
        }
        while (queue.Count > 0)
        {
            var w = queue.Dequeue();
            foreach (var item in adj[w])
            {
                if (!visited[item])
                {
                    prev[item] = w;

                    if (item == t)
                    {
                        Show2(prev);
                        print(prev, s, t);
                        return;
                    }
                    visited[item] = true;
                    queue.Enqueue(item);


                }
            }
        }
    }

    public void print(int[] perv, int s, int t)
    {
        if (perv[t] != -1 && t != s)
        {
            print(perv, s, perv[t]);
        }
        Console.WriteLine(t + " ");
    }

    public void Show()
    {
        for (int i = 0; i < v; i++)
        {
            Console.Write($"{i} ->");
            foreach (var item in adj[i])
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
    public void Show2(int[] perv)
    {
        for (int i = 0; i < perv.Length; i++)
        {
            Console.Write($"{i} -> {perv[i]}");
            Console.WriteLine();
        }
    }

    bool fount = false;
    public void dfs(int s, int t)
    {
        bool[] visited = new bool[v];
        int[] prev = new int[v];
        for (int i = 0; i < v; i++)
        {
            prev[i] = -1;
        }
        recurDfs(s, t, prev, visited);
        print(prev, s, t);
    }
    public void recurDfs(int w, int t, int[] prev, bool[] visited)
    {
        if (fount) return;
        visited[w] = true;
        if (w == t)
        {
            fount = true;
            return;
        }
        foreach (var item in adj[w])
        {
            if (!visited[item])
            {
                prev[item] = w;
                recurDfs(item, t, prev, visited);

            }
        }

    }


}

