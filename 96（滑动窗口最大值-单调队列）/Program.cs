
Solution solution = new Solution();
var a = solution.MaxSlidingWindow(new int[] { -5769, -7887, -5709, 4600, -7919, 9807, 1303, -2644, 1144, -6410, -7159, -2041, 9059, -663, 4612, -257, 2870, -6646, 8161, 3380, 6823, 1871, -4030, -1758, 4834, -5317, 6218, -4105, 6869, 8595, 8718, -4141, -3893, -4259, -3440, -5426, 9766, -5396, -7824, -3941, 4600, -1485, -1486, -4530, -1636, -2088, -5295, -5383, 5786, -9489, 3180, -4575, -7043, -2153, 1123, 1750, -1347, -4299, -4401, -7772, 5872, 6144, -4953, -9934, 8507, 951, -8828, -5942, -3499, -174, 7629, 5877, 3338, 8899, 4223, -8068, 3775, 7954, 8740, 4567, 6280, -7687, -4811, -8094, 2209, -4476, -8328, 2385, -2156, 7028, -3864, 7272, -1199, -1397, 1581, -9635, 9087, -6262, -3061, -6083, -2825, -8574, 5534, 4006, -2691, 6699, 7558, -453, 3492, 3416, 2218, 7537, 8854, -3321, -5489, -945, 1302, -7176, -9201, -9588, -140, 1369, 3322, -7320, -8426, -8446, -2475, 8243, -3324, 8993, 8315, 2863, -7580, -7949, 4400 }, 6);
Console.WriteLine(a);

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        CustomLinkedList<int> list = new CustomLinkedList<int>();
        for (int i = 0; i < k; i++)
        {
            while (list.Any() && nums[i] >= nums[list.LastOrDefault()])
            {
                list.RemoveLast();
            }
            list.AddLast(i);
        }

        var arr = new int[n - k + 1];
        arr[0] = nums[list.FirstOrDefault()];
        for (int i = k; i < n; i++)
        {
            while (list.Any() && nums[i] >= nums[list.LastOrDefault()])
            {
                list.RemoveLast();
            }
            list.AddLast(i);
            if (list.FirstOrDefault() == i - k)
            {
                list.RemoveFirst();
            }
            arr[i - k + 1] = nums[list.FirstOrDefault()];
        }
        return arr;
    }
}

public class CustomLinkedList<T>
{
    private Node<T> head;
    private Node<T> tial;
    public int Count { get; set; }
    public CustomLinkedList()
    {
        head = new Node<T>();
        tial = head;
        Count = 0;
    }

    public void AddLast(T t)
    {
        var node = new Node<T>();
        node.Data = t;
        node.Pre = tial;
        tial.Next = node;
        tial = node;
        Count++;
    }

    public bool Any()
    {
        return Count > 0;
    }
    public T FirstOrDefault()
    {
        return head.Next.Data;
    }
    public T LastOrDefault()
    {
        return tial.Data;
    }

    public void RemoveLast()
    {
        tial = tial.Pre;
        tial.Next = null;
        Count--;
    }
    public void RemoveFirst()
    {
        head.Next.Next.Pre = head;
        head.Next = head.Next.Next;
        Count--;
    }

    public class Node<T>
    {
        public Node<T> Pre { get; set; }
        public Node<T> Next { get; set; }
        public T Data { get; set; }
    }
}

