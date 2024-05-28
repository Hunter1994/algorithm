// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

int v = 4;
Graph g = new Graph(v);
g.Add(0, 1, 1);
g.Add(0, 2, 2);
g.Add(1, 2, 2);
dijkstra(0, 2, v, g);

void dijkstra(int s, int t, int v, Graph g)
{
    int[] predecessor = new int[v];
    Vertex[] vertexes = new Vertex[v];
    for (int i = 0; i < v; i++)
    {
        vertexes[i] = new Vertex(i, int.MaxValue);
    }
    Queue<Vertex> queue = new Queue<Vertex>();// 小顶堆 
    bool[] inqueue = new bool[v]; // 标记是否进入过队列
    vertexes[s].dist = 0;
    inqueue[s] = true;
    queue.Enqueue(vertexes[s]);
    while (queue.Count > 0)
    {
        var minVertex = queue.Dequeue();
        if (minVertex.id == t) break;
        foreach (var item in g.Agj[minVertex.id])
        {
            var nextVertex = vertexes[item.tis];
            if (minVertex.dist + item.w < nextVertex.dist)
            {
                nextVertex.dist = minVertex.dist + item.w;
                predecessor[nextVertex.id] = minVertex.id;
                if (!inqueue[nextVertex.id])
                {
                    queue.Enqueue(nextVertex);
                    inqueue[nextVertex.id] = true;
                }
            }
        }
    }
    Console.Write(s);
    print(s, t, predecessor);
    Console.WriteLine();
}

void print(int s, int t, int[] predecessor)
{
    if (s == t) return;
    print(s, predecessor[t], predecessor);
    Console.Write("-->" + t);
}




public class Graph
{
    public LinkedList<Edge>[] Agj;
    public int v;
    public Graph(int v)
    {
        this.v = v;
        this.Agj = new LinkedList<Edge>[v];
        for (int i = 0; i < v; i++)
        {
            this.Agj[i] = new LinkedList<Edge>();
        }
    }
    public void Add(int sid, int tis, int w)
    {
        var edge = new Edge(sid, tis, w);
        this.Agj[sid].AddLast(edge);
    }
}
public class Edge
{
    public int sid;
    public int tis;
    public int w;
    public Edge(int sid, int tis, int w)
    {
        this.sid = sid;
        this.tis = tis;
        this.w = w;
    }
}
public class Vertex
{
    public int id;
    public int dist;
    public Vertex(int id, int dist)
    {
        this.id = id;
        this.dist = dist;
    }
}