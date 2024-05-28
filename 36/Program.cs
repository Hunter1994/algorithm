// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int n = 3;
Graph g = new Graph(n);
g.Add(0, 1);
g.Add(1, 2);


var arr = new int[n];
for (int i = 0; i < n; i++)
{
    foreach (var item in g.adj[i])
    {
        arr[item]++;
    }
}
var q = new Queue<int>();
for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] == 0) q.Enqueue(i);
}

while (q.Count > 0)
{
    var i = q.Dequeue();
    Console.Write(i + "->");
    foreach (var item in g.adj[i])
    {
        arr[item]--;
        if (arr[item] == 0)
        {
            q.Enqueue(item);
        }
    }
}
Console.WriteLine();

public class Graph
{
    private int v;
    public LinkedList<int>[] adj;
    public Graph(int _v)
    {
        this.v = _v;
        adj = new LinkedList<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new LinkedList<int>();
        }
    }
    public void Add(int s, int t)
    {
        adj[s].AddLast(t);
    }
    public int GetV()
    {
        return v;
    }
}


