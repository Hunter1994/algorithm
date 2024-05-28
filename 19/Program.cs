// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] arr = new int[] { 1, 5, 6, 2, 3, 4 };
int num = 0;
merge(arr, 0, arr.Length - 1);

Console.WriteLine(num);
foreach (var item in arr)
{
    Console.WriteLine(item + " ");
}


void merge(int[] arr, int q, int r)
{
    if (q >= r) return;
    var p = (q + r) / 2;
    merge(arr, q, p);
    merge(arr, p + 1, r);
    op(arr, q, p, r);
}

void op(int[] arr, int q, int p, int r)
{
    int i = q;
    int j = p + 1;
    int k = 0;
    int[] temp = new int[r - q + 1];
    while (i <= p && j <= r)
    {
        if (arr[i] < arr[j])
        {
            temp[k++] = arr[i++];
        }
        else
        {
            num += p - i + 1;
            temp[k++] = arr[j++];
        }
    }
    if (i <= p)
    {
        while (i <= p)
        {
            temp[k++] = arr[i++];
        }
    }
    if (j <= r)
    {
        while (j <= r)
        {
            temp[k++] = arr[j++];
        }
    }

    for (int m = 0; m < temp.Length; m++)
    {
        arr[q + m] = temp[m];
    }
}