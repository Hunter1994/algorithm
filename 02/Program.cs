// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[] { 4, 2, 5, 12, 3 };
Sort(arr, 4);

void Sort(int[] arr, int k)
{
    QuickSort(arr, 0, arr.Length - 1, k);
    Console.WriteLine(arr[k - 1]);
}
void QuickSort(int[] arr, int p, int r, int k)
{
    if (p >= r)
    {
        return;
    }
    var q = Partition(arr, p, r);
    if (k - 1 == q)
    {
        return;
    }
    else if (k - 1 < q)
    {
        QuickSort(arr, p, q - 1, k);
    }
    else
    {
        QuickSort(arr, q + 1, r, k);
    }

}
int Partition(int[] arr, int p, int r)
{
    var vipot = arr[r];
    var i = p;
    int temp;
    for (int j = p; j <= r; j++)
    {
        if (arr[j] < vipot)
        {
            temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
            i++;
        }
    }
    temp = arr[i];
    arr[i] = arr[r];
    arr[r] = temp;
    return i;
}