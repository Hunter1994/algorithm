// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;

int[] arr = new int[] { 1, 3, 4, 5, 71, 2, 4, 6, 76 };
Sort(arr);
foreach (int i in arr)
{
    Console.WriteLine(i);
}
void Sort(int[] arr)
{
    QueckSort(arr, 0, arr.Length - 1);
}

void QueckSort(int[] arr, int p, int r)
{
    if (p >= r)
    { return; }
    var q = Partitioner(arr, p, r);
    QueckSort(arr, p, q - 1);
    QueckSort(arr, q + 1, r);
}

int Partitioner(int[] arr, int p, int r)
{
    var pivot = arr[r];
    int i = p;
    int temp = 0;
    for (int j = p; j < r; j++)
    {
        if (arr[j] < pivot)
        {
            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
        }
    }
    temp = arr[i];
    arr[i] = arr[r];
    arr[r] = temp;
    return i;
}