// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

Grpth g = new Grpth(4);
g.Add(0, 1);
g.Add(0, 2);
g.Add(2, 3);
g.Print();
Console.WriteLine();
g.topoSortByDFS();
public class Grpth
{
    public int V { get; set; }
    public LinkedList<int>[] Adj { get; set; }
    public Grpth(int v)
    {
        this.V = v;
        Adj = new LinkedList<int>[v];
        for (int i = 0; i < v; i++)
        {
            Adj[i] = new LinkedList<int>();
        }
    }
    public void Add(int i, int j)
    {
        Adj[i].AddLast(j);
    }

    public void topoSortByDFS()
    {
        LinkedList<int>[] inverseAdj = new LinkedList<int>[V];
        for (int i = 0; i < V; i++)
        {
            inverseAdj[i] = new LinkedList<int>();
        }

        for (int i = 0; i < V; i++)
        {
            foreach (int j in Adj[i])
            {
                inverseAdj[j].AddLast(i);
            }
        }

        bool[] b = new bool[V];

        for (int i = 0; i < V; i++)
        {
            if (!b[i])
            {
                b[i] = true;
                Dfs(i, inverseAdj, b);
            }
        }
    }
    private void Dfs(int i, LinkedList<int>[] inverseAdj, bool[] b)
    {

        foreach (int j in inverseAdj[i])
        {
            if (b[j]) continue;
            b[j] = true;
            Dfs(j, inverseAdj, b);
        }

        Console.Write(i + " ");
    }


    public void Print()
    {
        int[] arr = new int[V];
        for (int i = 0; i < V; i++)
        {
            foreach (var item in Adj[i])
            {
                arr[item] += 1;
            }
        }

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < V; i++)
        {
            if (arr[i] == 0)
                q.Enqueue(i);
        }

        while (q.Count > 0)
        {
            var data = q.Dequeue();
            Console.Write("->" + data + " ");
            foreach (var item in Adj[data])
            {
                arr[item] -= 1;
                if (arr[item] == 0) q.Enqueue(item);
            }
        }

    }

}
