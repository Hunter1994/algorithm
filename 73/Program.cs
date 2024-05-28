// See https://aka.ms/new-console-template for more information
int[] arr = { 1, 5, 6, 2, 3, 4 };
int num = 0;

sort(arr, 0, arr.Length - 1);
for (int l = 0; l < arr.Length; l++)
{
    Console.Write(arr[l]);
}
Console.WriteLine();
Console.WriteLine(num);
void sort(int[] arr, int p, int r)
{
    if (p >= r) return;
    var q = (p + r) / 2;
    sort(arr, p, q);
    sort(arr, q + 1, r);
    merge(arr, p, q, r);
}

void merge(int[] arr, int p, int q, int r)
{
    var temp = new int[r - p + 1];
    int i = 0;
    int j = p;
    int k = q + 1;
    while (j <= q && k <= r)
    {
        if (arr[j] <= arr[k])
        {
            temp[i++] = arr[j++];
        }
        else
        {
            num += (q - j + 1);
            temp[i++] = arr[k++];
        }
    }
    while (j <= q)
    {
        temp[i++] = arr[j++];
    }
    while (k <= r)
    {
        temp[i++] = arr[k++];
    }
    for (int m = 0; m < temp.Length; m++)
    {
        arr[p + m] = temp[m];
    }
}

