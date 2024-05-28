// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var n = 3;
Graph g = new Graph(n);
g.Add(0, 1);
g.Add(1, 2);

LinkedList<int>[] list = new LinkedList<int>[n];
for (int i = 0; i < n; i++)
{
    list[i] = new LinkedList<int>();
}
for (int i = 0; i < n; i++)
{
    foreach (var item in g.Adj[i])
    {
        list[item].AddLast(i);
    }
}

bool[] state = new bool[n];

for (int i = 0; i < n; i++)
{
    if (!state[i])
    {
        state[i] = true;
        dfs(i, list, state);
    }
}

void dfs(int i, LinkedList<int>[] list, bool[] state)
{
    foreach (var item in list[i])
    {
        if (state[item]) continue;
        state[item] = true;
        dfs(item, list, state);
    }
    Console.WriteLine(i);
}


public class Graph
{
    public LinkedList<int>[] Adj { get; set; }
    public Graph(int v)
    {
        Adj = new LinkedList<int>[v];
        for (int i = 0; i < v; i++)
        {
            Adj[i] = new LinkedList<int>();
        }
    }
    public void Add(int s, int t)
    {
        Adj[s].AddLast(t);
    }
}