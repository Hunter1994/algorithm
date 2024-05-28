int[][] _arr = new int[3][];
_arr[0] = [1, 2, 3, 4, 5, 6];
_arr[1] = [1, 8];
_arr[2] = [8, 9];

int[] res = new int[10];
int resIndex = 0;
PriorityQueue queue = new PriorityQueue(_arr.Length);
for (int i = 0; i < _arr.Length; i++)
{
    queue.Add(new PriorityQueue.Node(_arr[i][0], i, 0));
}

while (queue.Count() > 0)
{
    var node = queue.Pop();
    res[resIndex++] = node.data;
    if (node.index < _arr[node.location].Length - 1)
    {
        var newIndex = node.index + 1;
        queue.Add(new PriorityQueue.Node(_arr[node.location][newIndex], node.location, newIndex));
    }
}

foreach (var item in res)
{
    Console.Write(item + " ");
}
Console.ReadLine();

class PriorityQueue
{
    private Node[] _arr;
    private int _index;
    public PriorityQueue(int n)
    {
        _arr = new Node[n + 1];
        _index = 1;
    }
    public int Count()
    {
        return _index - 1;
    }
    public void Add(Node i)
    {
        if (_index == _arr.Length) throw new Exception("队列已满");
        _arr[_index] = i;
        var p = _index;
        while (p > 0)
        {
            var pp = p / 2;
            if (pp > 0 && _arr[p].data < _arr[pp].data)
            {
                (_arr[p], _arr[pp]) = (_arr[pp], _arr[p]);
            }
            else
                break;

            p = pp;
        }
        _index++;
    }
    public Node Pop()
    {
        if (_index <= 1) throw new Exception("队列为空");
        _index--;
        var data = _arr[1];
        (_arr[_index], _arr[1]) = (_arr[1], _arr[_index]);
        var p = 1;
        while (p < _index)
        {
            var minp = p;
            if (p * 2 < _index && _arr[p].data > _arr[p * 2].data)
            {
                minp = p * 2;
            }
            if (p * 2 + 1 < _index && _arr[minp].data > _arr[p * 2 + 1].data)
            {
                minp = p * 2 + 1;
            }
            if (minp == p) break;

            (_arr[p], _arr[minp]) = (_arr[minp], _arr[p]);
            p = minp;
        }
        return data;
    }
    public class Node
    {
        public int data { get; set; }
        public int index { get; set; }
        public int location { get; set; }
        public Node(int d, int l, int i)
        {
            this.data = d;
            this.location = l;
            this.index = i;
        }
    }

}

