// See https://aka.ms/new-console-template for more information
using System.Text;

var result = new List<List<int>>();
allsort(new[] { 1, 2, 3 }, 0, result);

Console.WriteLine(result);


void allsort(int[] arr, int start, List<List<int>> result)
{
    if (start == arr.Length - 1)
    {
        result.Add(new List<int>(arr));
        return;
    }

    for (int i = start; i < arr.Length; i++)
    {
        swap(arr, start, i);
        allsort(arr, start + 1, result);
        swap(arr, start, i);
    }
}

void swap(int[] arr, int i, int j)
{
    var temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}


int f(int n)
{
    if (n <= 0) return 0;
    if (n == 1) return 1;
    if (n == 2) return 2;
    return f(n - 1) + f(n - 2);
}


int f1(int n)
{
    if (n == 1) return 1;
    if (n == 2) return 2;
    return n * f1(n - 2);
}
