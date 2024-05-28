
using System.Net.NetworkInformation;


PriorityQueue priorityQueue = new(5);

priorityQueue.Add(3);
priorityQueue.Add(6);
priorityQueue.Add(5);

Console.WriteLine(priorityQueue.Pop());
Console.WriteLine(priorityQueue.Pop());
Console.WriteLine(priorityQueue.Pop());

public class PriorityQueue
{
    private int[] _arr;
    private int _index;
    private int _count;
    public PriorityQueue(int n)
    {
        _arr = new int[n + 1];
        _index = 1;
        _count = 0;
    }

    public void Add(int i)
    {
        if (_count == _arr.Length) throw new Exception("队列已满");
        _arr[_index] = i;
        var p = _index / 2;
        while (p > 0)
        {
            if (_arr[_index] > _arr[p])
            {
                (_arr[_index], _arr[p]) = (_arr[p], _arr[_index]);
            }
            p = p / 2;
        }
        _index++;
        _count++;
    }

    public int Pop()
    {
        if (_count == 0) throw new Exception("队列为空");
        var data = _arr[1];
        _index--;
        _count--;
        (_arr[_index], _arr[1]) = (_arr[1], _arr[_index]);
        var p = 1;
        while (p < _index)
        {
            var maxp = p;
            if (maxp * 2 < _index && _arr[maxp * 2] > _arr[maxp])
            {
                maxp = maxp * 2;
            }
            if (maxp * 2 + 1 < _index && _arr[maxp * 2 + 1] > _arr[maxp])
            {
                maxp = maxp * 2 + 1;
            }
            if (maxp == p) break;
            (_arr[maxp], _arr[p]) = (_arr[p], _arr[maxp]);
            p = maxp;
        }
        return data;
    }



}