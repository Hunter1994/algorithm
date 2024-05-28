


Griph griph = new(14);
griph.AddEdge(0, 1, 20);
griph.AddEdge(0, 4, 60);
griph.AddEdge(0, 5, 60);
griph.AddEdge(0, 6, 60);
griph.AddEdge(1, 0, 20);
griph.AddEdge(1, 2, 20);
griph.AddEdge(2, 1, 20);
griph.AddEdge(2, 3, 10);
griph.AddEdge(3, 2, 10);
griph.AddEdge(3, 12, 40);
griph.AddEdge(3, 13, 30);
griph.AddEdge(4, 0, 60);
griph.AddEdge(4, 8, 50);
griph.AddEdge(4, 12, 40);
griph.AddEdge(5, 0, 60);
griph.AddEdge(5, 8, 70);
griph.AddEdge(5, 9, 80);
griph.AddEdge(5, 10, 50);
griph.AddEdge(6, 0, 60);
griph.AddEdge(6, 7, 70);
griph.AddEdge(6, 13, 50);
griph.AddEdge(7, 6, 70);
griph.AddEdge(7, 11, 50);
griph.AddEdge(8, 4, 50);
griph.AddEdge(8, 5, 70);
griph.AddEdge(8, 9, 50);
griph.AddEdge(9, 5, 80);
griph.AddEdge(9, 8, 50);
griph.AddEdge(9, 10, 60);
griph.AddEdge(10, 5, 50);
griph.AddEdge(10, 9, 60);
griph.AddEdge(10, 11, 60);
griph.AddEdge(11, 7, 50);
griph.AddEdge(11, 10, 60);
griph.AddEdge(12, 3, 40);
griph.AddEdge(12, 4, 40);
griph.AddEdge(13, 3, 30);

griph.AddVertex(0, 320, 630);
griph.AddVertex(1, 300, 630);
griph.AddVertex(2, 280, 625);
griph.AddVertex(3, 270, 630);
griph.AddVertex(4, 320, 700);
griph.AddVertex(5, 360, 620);
griph.AddVertex(6, 320, 590);
griph.AddVertex(7, 370, 580);
griph.AddVertex(8, 350, 730);
griph.AddVertex(9, 390, 690);
griph.AddVertex(10, 400, 620);
griph.AddVertex(11, 400, 590);
griph.AddVertex(12, 270, 700);
griph.AddVertex(13, 270, 630);

griph.A(0, 10);




public class Griph
{
    private LinkedList<Edge>[] edges;
    private Vertex[] vertices;
    private int _v;
    public Griph(int vertexCount)
    {
        edges = new LinkedList<Edge>[vertexCount];
        for (int i = 0; i < edges.Length; i++)
        {
            edges[i] = new LinkedList<Edge>();
        }
        vertices = new Vertex[vertexCount];
        _v = vertexCount;
    }


    public void AddEdge(int s, int t, int w)
    {
        edges[s].AddLast(new Edge(s, t, w));
    }
    public void AddVertex(int v, int x, int y)
    {
        vertices[v] = new Vertex(v, x, y);
    }

    public class Edge
    {
        public int s;
        public int t;
        public int w;
        public Edge(int s, int t, int w)
        {
            this.s = s;
            this.t = t;
            this.w = w;
        }
    }
    public class Vertex : IComparable
    {
        public int v;
        public int dict;
        public int f;
        public int x;
        public int y;
        public Vertex(int v, int x, int y)
        {
            this.v = v;
            this.dict = int.MaxValue;
            this.x = x;
            this.y = y;
        }
        public void Opf(Vertex vertex)
        {
            f = Math.Abs(vertex.x - this.x) + Math.Abs(vertex.y - this.y);
        }

        public int CompareTo(object? obj)
        {
            var o = obj as Vertex;
            if ((this.dict + f) > (o.dict + o.f)) return 1;
            else if ((this.dict + f) < (o.dict + o.f)) return -1;
            else return 0;
        }
    }

    public void A(int s, int t)
    {
        int[] path = new int[_v];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = -1;
        }
        PriorityQueue<int, Vertex> priorityQueue = new(_v);
        bool[] b = new bool[_v];

        b[s] = true;
        vertices[s].dict = 0;
        vertices[s].Opf(vertices[t]);
        priorityQueue.Enqueue(s, vertices[s]);

        while (priorityQueue.Count() > 0)
        {
            var current = priorityQueue.Pop();
            foreach (var edge in edges[current.Item1])
            {
                var next = vertices[edge.t];
                next.Opf(vertices[t]);
                if (current.Item2.dict + edge.w < next.dict)
                {
                    next.dict = current.Item2.dict + edge.w;
                    path[next.v] = current.Item1;

                    if (next.v == t)
                    {
                        priorityQueue.Clear();
                        break;
                    }

                    if (b[next.v])
                    {
                        priorityQueue.Update(next.v, next);
                    }
                    else
                    {
                        b[next.v] = true;
                        priorityQueue.Enqueue(next.v, next);
                    }
                }

            }

        }

        Console.Write(s);
        Print(path, s, t);
        Console.WriteLine();

    }

    void Print(int[] path, int s, int t)
    {
        if (s == t) return;
        Print(path, s, path[t]);
        Console.Write("->" + t);
    }
}

public class PriorityQueue<Key, T>
where T : IComparable
where Key : IComparable
{
    private (Key, T)[] _arr;
    private int _count;
    private int _index;
    private int _v;
    public PriorityQueue(int v)
    {
        this._v = v;
        _count = 0;
        _index = 1;
        _arr = new (Key, T)[v + 1];
    }
    public (Key, T) Pop()
    {
        if (_count == 0) throw new Exception("队列为空");
        var data = _arr[1];
        (_arr[1], _arr[_index - 1]) = (_arr[_index - 1], _arr[1]);
        _index--;
        _count--;

        Down(1);
        return data;
    }
    public void Enqueue(Key key, T t)
    {
        if (_count == _v) throw new Exception("队列已满");
        _arr[_index] = (key, t);
        Up(_index);
        _index++;
        _count++;
    }
    public void Update(Key key, T t)
    {
        int i = 1;
        for (; i < _index; i++)
        {
            if (key.CompareTo(_arr[i].Item1) == 0)
            {
                break;
            }
        }
        if (i == _index) throw new Exception("未找到！");

        _arr[i] = (key, t);
        Up(i);
        Down(1);

    }

    private void Down(int i)
    {
        while (i < _index)
        {
            var p = i;
            if (i * 2 < _index && _arr[i].Item2.CompareTo(_arr[i * 2].Item2) == 1)
            {
                p = p * 2;
            }
            if (i * 2 + 1 < _index && _arr[p].Item2.CompareTo(_arr[i * 2 + 1].Item2) == 1)
            {
                p = i * 2 + 1;
            }
            if (p == i) break;
            (_arr[i], _arr[p]) = (_arr[p], _arr[i]);
            i = p;
        }
    }
    private void Up(int i)
    {
        while (i > 0)
        {
            var p = i;
            if (p / 2 > 0 && _arr[p].Item2.CompareTo(_arr[p / 2].Item2) == -1)
            {
                p = p / 2;
            }
            if (p == i) break;
            (_arr[i], _arr[p]) = (_arr[p], _arr[i]);
            i = p;
        }

    }


    public int Count()
    {
        return _count;
    }
    public void Clear()
    {
        _index = 1;
        _count = 0;
    }
}