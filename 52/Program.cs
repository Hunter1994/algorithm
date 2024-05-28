// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[] { 4, 5, 1, 9, 1, 2, 10 };
var n = arr.Length;
// Guibing guibing = new Guibing(arr, n);
// guibing.Run();
QuickSort quickSort = new QuickSort(arr, n);
quickSort.Run(5);

public class QuickSort
{
    int[] arr;
    int n;
    public QuickSort(int[] arr, int n)
    {
        this.arr = arr;
        this.n = n;
    }
    public void Run()
    {
        sort(0, n - 1);

        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
    public void Run(int k)
    {
        var res = sort1(0, n - 1, k);
        Console.WriteLine(res);
    }
    public int sort1(int start, int end, int k)
    {
        if (start >= end) return arr[k - 1];
        var p = positition(start, end);
        if (k < (p + 1))
            return sort1(start, p - 1, k);
        else
            return sort1(p + 1, end, k);
    }

    public void sort(int start, int end)
    {
        if (start >= end) return;
        var p = positition(start, end);
        sort(start, p - 1);
        sort(p + 1, end);
    }
    public int positition(int start, int end)
    {
        var pivot = arr[end];
        var i = start;
        var j = start;
        for (; j < end; j++)
        {
            if (arr[j] < pivot)
            {
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
                i++;
            }
        }
        var temp2 = arr[end];
        arr[end] = arr[i];
        arr[i] = temp2;
        return i;
    }

}

public class Guibing
{

    int[] arr;
    int n;
    public Guibing(int[] arr, int n)
    {
        this.arr = arr;
        this.n = n;
    }
    public void Run()
    {
        f(0, n - 1);

        for (int i = 0; i < n; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }

    void f(int start, int end)
    {
        if (start >= end) return;
        var p = (end + start) / 2;
        f(start, p);//laft
        f(p + 1, end);//right
        merge(start, end, p);
    }
    void merge(int start, int end, int p)
    {
        int left = start;
        int right = p + 1;
        var temp = new int[end - start + 1];
        int tempP = 0;
        while (left <= p && right <= end)
        {
            if (arr[left] <= arr[right])
            {
                temp[tempP++] = arr[left++];
            }
            else
            {
                temp[tempP++] = arr[right++];
            }
        }
        while (left <= p)
        {
            temp[tempP++] = arr[left++];
        }
        while (right <= end)
        {
            temp[tempP++] = arr[right++];
        }
        for (int i = 0; i < temp.Length; i++)
        {
            arr[start + i] = temp[i];
        }

    }
}



