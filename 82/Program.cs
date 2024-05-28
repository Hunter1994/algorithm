// See https://aka.ms/new-console-template for more information

Griph g = new Griph(5);
// g.Add(0, 1, 1);
// g.Add(0, 2, 1);
// g.Add(0, 3, 10);
// g.Add(1, 3, 2);
// g.Add(2, 3, 3);
// g.Add(1, 0, 1);
// g.Add(2, 0, 1);
// g.Add(3, 0, 10);
// g.Add(3, 1, 2);
// g.Add(3, 2, 3);
g.Add(0, 1, 1);
g.Add(0, 2, 1);
g.Add(1, 3, 4);
g.Add(2, 3, 1);
g.Add(2, 4, 10);
g.Add(3, 4, 2);


g.Print(0, 4);

public class Griph
{
    public LinkedList<Edig>[] adj;
    public int v;
    public Griph(int v)
    {
        this.v = v;
        adj = new LinkedList<Edig>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new LinkedList<Edig>();
        }
    }
    public void Add(int s, int t, int w)
    {
        adj[s].AddLast(new Edig(s, t, w));
    }

    public void Print(int s, int t)
    {
        int[] predecessor = new int[v];
        Vertex[] vertices = new Vertex[v];
        for (int i = 0; i < v; i++)
        {
            vertices[i] = new Vertex(i, int.MaxValue);
        }
        var b = new bool[v];

        var queue = new PriorityQueue(v);
        vertices[s].dist = 0;
        queue.Add(vertices[s]);
        b[s] = true;

        while (queue.count > 0)
        {
            var minVertex = queue.Get();
            if (minVertex.id == t) break;
            foreach (var edig in adj[minVertex.id])
            {
                var nextVertex = vertices[edig.t];
                if (minVertex.dist + edig.w < nextVertex.dist)
                {
                    nextVertex.dist = minVertex.dist + edig.w;
                    predecessor[nextVertex.id] = minVertex.id;

                    if (b[nextVertex.id])
                    {
                        queue.Update(nextVertex);
                    }
                    else
                    {
                        b[nextVertex.id] = true;
                        queue.Add(nextVertex);
                    }
                }

            }

        }
        Console.Write(s);
        write(predecessor, t, s);
        Console.WriteLine();
    }

    void write(int[] predecessor, int p, int s)
    {
        if (p == s)
        {
            return;
        }
        write(predecessor, predecessor[p], s);
        Console.Write("->" + p + " ");
    }
}

public class PriorityQueue
{
    public Vertex[] vertices;
    public int count;
    private int i = 1;
    public PriorityQueue(int count)
    {
        this.count = count;
        vertices = new Vertex[count];
        vertices[0] = new Vertex(-1, -1);
    }

    public Vertex Get()
    {
        var top = vertices[1];
        i--;
        if (i == 1) return top;

        var last = vertices[i];
        vertices[1] = last;


        var p = 1;
        while (p <= i)
        {
            int minPos = p;

            if (p * 2 <= i && vertices[minPos].dist > vertices[p * 2].dist) minPos = p * 2;
            if (p * 2 + 1 <= i && vertices[minPos].dist > vertices[p * 2 + 1].dist) minPos = p * 2 + 1;

            if (minPos != p)
            {
                var temp = vertices[p];
                vertices[p] = vertices[minPos];
                vertices[minPos] = temp;
            }
            else { break; }
            p = minPos;
        }

        return top;
    }
    public void Add(Vertex vertex)
    {
        if (i >= count) return;
        vertices[i] = vertex;
        var p = i;
        while (p / 2 > 0)
        {
            if (vertices[p / 2].dist > vertices[p].dist)
            {
                var temp = vertices[p / 2];
                vertices[p / 2] = vertices[p];
                vertices[p] = temp;
            }
            p = p / 2;
        }
        i++;
    }
    public void Update(Vertex vertex)
    {
        for (int i = 1; i < count; i++)
        {
            if (vertices[i].id == vertex.id)
            {

                vertices[i] = vertex;

                var p = i;
                while (p / 2 >= 1)
                {
                    if (vertices[p / 2].dist > vertices[p].dist)
                    {
                        var temp = vertices[p / 2];
                        vertices[p / 2] = vertices[p];
                        vertices[p] = temp;
                    }
                    else
                    {
                        return;
                    }
                }

                return;
            }
        }
    }
}

public class Vertex
{
    public int id;
    public int dist;
    public Vertex(int id, int dict)
    {
        this.id = id;
        this.dist = dict;
    }
}
public class Edig
{
    public int s;
    public int t;
    public int w;

    public Edig(int s, int t, int w)
    {
        this.s = s;
        this.t = t;
        this.w = w;
    }
}