var arr = new int[] { 4, 1, 10, 1, 5 };

sort(arr);

for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();

void sort(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
}

void selectsort(int[] arr)
{
    int minIndex = 0;
    while (minIndex < arr.Length - 1)
    {
        var min = minIndex;
        for (int i = minIndex + 1; i < arr.Length; i++)
        {
            if (arr[min] > arr[i])
            {
                min = i;
            }
        }

        var temp = arr[min];
        arr[min] = arr[minIndex];
        arr[minIndex] = temp;
        minIndex++;
    }
}

void insertsort(int[] arr)
{
    for (int i = 1; i < arr.Length; i++)
    {
        var v = arr[i];
        int j = i - 1;
        for (; j >= 0; j--)
        {
            if (arr[j] > v)
            {
                arr[j + 1] = arr[j];
            }
            else break;
        }
        arr[j + 1] = v;
    }
}

void quicksort(int[] arr, int p, int r)
{
    if (p >= r) return;
    var q = positation(arr, p, r);
    quicksort(arr, p, q - 1);
    quicksort(arr, q + 1, r);
}

int positation(int[] arr, int p, int r)
{
    var v = arr[r];
    var i = p;
    for (int j = p; j < r; j++)
    {
        if (arr[j] < v)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
        }
    }
    var temp2 = arr[i];
    arr[i] = arr[r];
    arr[r] = temp2;
    return i;
}











void mergesort(int[] arr, int p, int r)
{
    if (p >= r) return;
    var q = (p + r) / 2;
    mergesort(arr, p, q);
    mergesort(arr, q + 1, r);
    merge(arr, p, q, r);
}

void merge(int[] arr, int p, int q, int r)
{
    var temp = new int[r - p + 1];
    var index = 0;
    var i = p;
    var j = q + 1;
    while (i <= q && j <= r)
    {
        if (arr[i] < arr[j])
        {
            temp[index++] = arr[i++];
        }
        else
        {
            temp[index++] = arr[j++];
        }
    }
    while (i <= q)
    {
        temp[index++] = arr[i++];
    }
    while (j <= r)
    {
        temp[index++] = arr[j++];
    }
    for (int k = 0; k < index; k++)
    {
        arr[p + k] = temp[k];
    }
}