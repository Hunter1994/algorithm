
using System.Data;

Griph griph = new(6);
griph.AddEdge(0, 1, 10);
griph.AddEdge(0, 4, 15);
griph.AddEdge(1, 2, 15);
griph.AddEdge(1, 3, 2);
griph.AddEdge(2, 5, 5);
griph.AddEdge(3, 2, 1);
griph.AddEdge(3, 5, 12);
griph.AddEdge(4, 5, 10);

griph.Dijkstra(0, 5);

public class Griph
{
    public LinkedList<Edge>[] edges;
    private int _count;
    public Griph(int count)
    {
        edges = new LinkedList<Edge>[count];
        for (int i = 0; i < count; i++)
        {
            edges[i] = new LinkedList<Edge>();
        }
        _count = count;
    }
    public void AddEdge(int s, int t, int l)
    {
        edges[s].AddLast(new Edge()
        {
            s = s,
            t = t,
            l = l
        });
    }

    public class Edge
    {
        public int s { get; set; }
        public int t { get; set; }
        public int l { get; set; }
    }


    public void Dijkstra(int s, int t)
    {
        int[] path = new int[_count];
        Vertex[] vertices = new Vertex[_count];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vertex() { v = i, dist = int.MaxValue };
        }
        bool[] b = new bool[_count];
        PriorityQueue priorityQueue = new(_count + 1);

        b[s] = true;
        vertices[s].dist = 0;
        priorityQueue.Add(vertices[s]);

        while (priorityQueue.Count() > 0)
        {
            var node = priorityQueue.Pop();
            if (node.v == t) break;

            foreach (var item in edges[node.v])
            {
                var dict = node.dist + item.l;
                var next = vertices[item.t];
                if (dict < next.dist)
                {
                    vertices[next.v].dist = dict;
                    path[next.v] = node.v;

                    if (!b[next.v])
                    {
                        b[next.v] = true;
                        priorityQueue.Add(vertices[next.v]);
                    }
                    else
                    {
                        priorityQueue.Update(vertices[next.v]);
                    }

                }

            }

        }
        Console.Write(s);
        Print(path, s, t);
        Console.WriteLine();
    }
    public void Print(int[] path, int s, int t)
    {
        if (s == t) return;
        Print(path, s, path[t]);
        Console.Write("->" + t);
    }
}
public class Vertex
{
    public int dist { get; set; }
    public int v { get; set; }
}

public class PriorityQueue
{
    private Vertex[] _arr;
    private int _count;
    private int _v;
    private int _index;
    public PriorityQueue(int v)
    {
        v += 1;
        _arr = new Vertex[v];
        _v = v;
        _count = 0;
        _index = 1;
    }
    public Vertex Pop()
    {
        if (_count == 0) throw new DataException("队列为空");
        var data = _arr[1];
        _index--;
        _count--;
        if (_index > 1)
        {
            (_arr[1], _arr[_index]) = (_arr[_index], _arr[1]);

            down(1);

        }
        return data;
    }
    public void Add(Vertex t)
    {
        _arr[_index] = t;

        up(_index);
        _index++;
        _count++;
    }

    public void Update(Vertex t)
    {
        int i = 1;
        for (; i < _arr.Length; i++)
        {
            if (_arr[i].v == t.v) break;
        }
        if (i == _arr.Length) throw new Exception("未找到");
        _arr[i].dist = t.dist;

        up(i);
        down(1);

    }

    private void up(int i)
    {
        var p = i;
        while (p > 0)
        {
            var min = p;
            if (min / 2 > 0 && _arr[min / 2].dist > _arr[p].dist)
            {
                min = min / 2;
            }
            if (min == p) break;
            (_arr[min], _arr[p]) = (_arr[p], _arr[min]);
            p = min;
        }
    }

    private void down(int i)
    {
        var p = i;
        while (p < _index)
        {
            var min = p;
            if (min * 2 < _index && _arr[min * 2].dist < _arr[p].dist)
            {
                min = min * 2;
            }
            if (min * 2 + 1 < _index && _arr[min * 2 + 1].dist < _arr[min].dist)
            {
                min = min * 2 + 1;
            }
            if (min == p) break;
            (_arr[min], _arr[p]) = (_arr[p], _arr[min]);
            p = min;
        }
    }
    public int Count()
    {
        return _count;
    }
}