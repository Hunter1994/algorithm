
using System.Collections;


// var arr = new int[] { -5769, -7887, -5709, 4600, -7919, 9807, 1303, -2644, 1144, -6410, -7159, -2041, 9059, -663, 4612, -257, 2870, -6646, 8161, 3380, 6823, 1871, -4030, -1758, 4834, -5317, 6218, -4105, 6869, 8595, 8718, -4141, -3893, -4259, -3440, -5426, 9766, -5396, -7824, -3941, 4600, -1485, -1486, -4530, -1636, -2088, -5295, -5383, 5786, -9489, 3180, -4575, -7043, -2153, 1123, 1750, -1347, -4299, -4401, -7772, 5872, 6144, -4953, -9934, 8507, 951, -8828, -5942, -3499, -174, 7629, 5877, 3338, 8899, 4223, -8068, 3775, 7954, 8740, 4567, 6280, -7687, -4811, -8094, 2209, -4476, -8328, 2385, -2156, 7028, -3864, 7272, -1199, -1397, 1581, -9635, 9087, -6262, -3061, -6083, -2825, -8574, 5534, 4006, -2691, 6699, 7558, -453, 3492, 3416, 2218, 7537, 8854, -3321, -5489, -945, 1302, -7176, -9201, -9588, -140, 1369, 3322, -7320, -8426, -8446, -2475, 8243, -3324, 8993, 8315, 2863, -7580, -7949, 4400 };
// // var arr = new int[] {
// //   -5351, 4471, 3738, 5256, -1644, -8322, -4507, -6337, 821, 3626,
// //   3804, 3957, 7675,  545, -3593, -760, 199, -7339,
// //   -6963, -8857, 5111};

// var queue = new CustomPriorityQueue<(int, int), int>(arr.Length, new IntIComparer());
// // var queue2 = new PriorityQueue(arr.Length);

// for (int i = 0; i < arr.Length; i++)
// {
//     queue.Enqueue((i, arr[i]), arr[i]);
//     //queue2.Enqueue(arr[i]);
// }

// List<int> list = new List<int>();
// for (int i = 0; i < arr.Length; i++)
// {
//     var k = queue.GetTop();
//     list.Add(k.Item2);
//     queue.Remove(x => x.Item1 == k.Item1);
//     if (i > 0)
//     {
//         if (list[i - 1] < list[i])
//         {
//             throw new Exception(i.ToString());
//         }
//     }
// }

Solution solution = new Solution();
var a = solution.MaxSlidingWindow(new int[] { -5769, -7887, -5709, 4600, -7919, 9807, 1303, -2644, 1144, -6410, -7159, -2041, 9059, -663, 4612, -257, 2870, -6646, 8161, 3380, 6823, 1871, -4030, -1758, 4834, -5317, 6218, -4105, 6869, 8595, 8718, -4141, -3893, -4259, -3440, -5426, 9766, -5396, -7824, -3941, 4600, -1485, -1486, -4530, -1636, -2088, -5295, -5383, 5786, -9489, 3180, -4575, -7043, -2153, 1123, 1750, -1347, -4299, -4401, -7772, 5872, 6144, -4953, -9934, 8507, 951, -8828, -5942, -3499, -174, 7629, 5877, 3338, 8899, 4223, -8068, 3775, 7954, 8740, 4567, 6280, -7687, -4811, -8094, 2209, -4476, -8328, 2385, -2156, 7028, -3864, 7272, -1199, -1397, 1581, -9635, 9087, -6262, -3061, -6083, -2825, -8574, 5534, 4006, -2691, 6699, 7558, -453, 3492, 3416, 2218, 7537, 8854, -3321, -5489, -945, 1302, -7176, -9201, -9588, -140, 1369, 3322, -7320, -8426, -8446, -2475, 8243, -3324, 8993, 8315, 2863, -7580, -7949, 4400 }, 6);
Console.WriteLine(a);


// var queue = new CustomPriorityQueue<(int, int), int>(3, new IntIComparer());
// queue.Enqueue((1, 1), 1);
// queue.Enqueue((2, 2), 2);
// queue.Enqueue((3, 3), 3);
// queue.RemoveIndexOf(1);
// var a = queue.Dequeue();
// var a1 = queue.Dequeue();
// var a2 = queue.Dequeue();
// System.Console.WriteLine();



public interface ICustomPriorityQueue<TElement, TPriority>
{
    void Enqueue(TElement element, TPriority priority);
    TElement Dequeue();
    TElement GetTop();
    void Remove(Func<TElement, bool> func);
}


public class CustomPriorityQueue<TElement, TPriority> : ICustomPriorityQueue<TElement, TPriority>
{
    private (TElement, TPriority)[] _nodes;
    private int _size;
    private int _n;
    private IComparer<TPriority> _comparer;

    public CustomPriorityQueue(int n, IComparer<TPriority> comparer)
    {
        _n = n + 1;
        _nodes = new (TElement, TPriority)[_n];
        _size = 1;
        _comparer = comparer;
    }
    public TElement Dequeue()
    {
        if (_size == 1) throw new Exception("空间已空");
        var node = _nodes[1].Item1;
        _nodes[1] = _nodes[--_size];
        sink(1);
        return node;
    }

    private void sink(int p)
    {
        while (p * 2 <= _size)
        {
            var j = p * 2;
            if (p * 2 < _size && _comparer.Compare(_nodes[j].Item2, _nodes[j + 1].Item2) > 0)
            {
                j++;
            }

            if (_comparer.Compare(_nodes[p].Item2, _nodes[j].Item2) > 0)
            {
                var temp = _nodes[j];
                _nodes[j] = _nodes[p];
                _nodes[p] = temp;
            }

            p = j;
        }

    }

    public void Enqueue(TElement element, TPriority priority)
    {
        if (_size == _n) throw new Exception("空间已满");
        _nodes[_size++] = (element, priority);

        Up(_size - 1);
    }

    private void Up(int p)
    {
        while (p > 1 && _comparer.Compare(_nodes[p].Item2, _nodes[p / 2].Item2) < 0)
        {
            var temp = _nodes[p / 2];
            _nodes[p / 2] = _nodes[p];
            _nodes[p] = temp;

            p = p / 2;
        }
    }


    public TElement GetTop()
    {
        if (_size == 1) throw new Exception("空间已空");
        return _nodes[1].Item1;
    }

    public void Remove(Func<TElement, bool> func)
    {
        if (_size == 1) throw new Exception("空间已空");
        int index = 1;
        for (; index < _n; index++)
        {
            if (func(_nodes[index].Item1))
            {
                break;
            }
        }
        _nodes[index] = _nodes[--_size];

        Up(index);
        sink(index);
    }

}

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var queue = new CustomPriorityQueue<(int, int), int>(k, new IntIComparer());
        var n = nums.Length - k + 1;
        var arr = new int[n];
        var index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i < k - 1)
                queue.Enqueue((i, nums[i]), nums[i]);
            else
            {
                queue.Enqueue((i, nums[i]), nums[i]);
                var data = queue.GetTop();
                arr[index++] = data.Item2;
                queue.Remove(x => x.Item1 == i + 1 - k);
            }
        }
        return arr;
    }
}

public class IntIComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x == y) return 0;
        else if (x < y) return 1;
        else
        {
            return -1;
        }
    }
}

