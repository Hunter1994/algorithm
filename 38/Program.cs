// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Graph
{
    
}
public class Edge
{
    public int sid;
    public int tis;
    public int w;
    public Edge(int sid,int tis,int w)
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
    public Vertex(int id,int dist)
    {
        this.id = id;
        this.dist = dist;
    }
}