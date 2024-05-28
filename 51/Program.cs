// See https://aka.ms/new-console-template for more information
// int[] arr = new[] { 1, 2, 3, 6, 5, 4, 1 };
int[] arr = new[] { 2, 1, 3, 6, 5, 4, 1 };
var n = arr.Length;
// select();
// insertSort();
// for (int k = 0; k < n; k++)
// {
//     Console.Write(arr[k] + " ");
// }
// Console.WriteLine();
insertSort();

void select()
{
    for (int i = 0; i < n; i++)
    {
        var minIndex = i;
        for (int k = i + 1; k < n; k++)
        {
            if (arr[k] < arr[i])
            {
                minIndex = k;
            }
        }
        if (i != minIndex)
        {
            var temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
}

void cr()
{
    for (int i = 1; i < n; i++)
    {
        if (arr[i] < arr[i - 1])
        {
            var temp = arr[i];
            int j = i - 1;
            for (; j >= 0; j--)
            {
                if (temp < arr[j])
                {
                    arr[j + 1] = arr[j];
                }
                else break;
            }
            arr[j + 1] = temp;
        }
    }
}

void mp()
{
    int x = 0;
    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j < n - i; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                x++;
                var temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }

    Console.WriteLine(x);
}


void insertSort()
{
    Node n1 = new(1, null);
    Node n2 = new(4, n1);
    Node n3 = new(5, n2);
    Node n4 = new(6, n3);
    Node n5 = new(3, n4);
    Node n6 = new(1, n5);
    Node n7 = new(2, n6);
    Node n8 = new(-1, n7);

    var p = n8.Next.Next;
    var preP = n8.Next;
    while (p != null)
    {
        var prepre = n8;
        var k = n8.Next;
        while (k != null && k != p)
        {
            if (p.Value < k.Value)
            {
                //删除p
                preP.Next = p.Next;
                //插入p
                p.Next = k;
                prepre.Next = p;
                break;
            }
            prepre = k;
            k = k.Next;
        }
        preP = p;
        p = p.Next;
    }


    var show = n8.Next;
    while (show != null)
    {
        Console.Write(show.Value + " ");
        show = show.Next;
    }
    Console.WriteLine();
}


public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node(int value, Node next)
    {
        Value = value;
        Next = next;
    }
}