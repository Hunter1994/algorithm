// See https://aka.ms/new-console-template for more information
var arr = new int[] { 6, 1, 7, 4, 8, 1 };
var n = arr.Length;
quicksort();
for (int i = 0; i < n; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();


void quicksort()
{
    quicksort_c(0, n - 1);
}
void quicksort_c(int p, int r)
{
    if (p >= r) return;
    var povit = position(p, r);
    quicksort_c(p, povit - 1);
    quicksort_c(povit + 1, r);
}
int position(int p, int r)
{
    var povit = arr[r];
    var i = p;
    for (int j = p; j < r; j++)
    {
        if (arr[j] < povit)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i++] = temp;
        }
    }
    var temp2 = arr[r];
    arr[r] = arr[i];
    arr[i] = temp2;
    return i;
}



void mergesort()
{
    sortMerge(0, n - 1);
}
void sortMerge(int p, int r)
{
    if (p >= r) return;
    var q = (p + r) / 2;
    sortMerge(p, q);
    sortMerge(q + 1, r);
    merge(p, q, r);
}
void merge(int p, int q, int r)
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
    for (int k = 0; k < temp.Length; k++)
    {
        arr[p++] = temp[k];
    }
}


void select()
{
    var s = 0;
    while (s < n - 1)
    {
        var min = s;
        for (int i = s + 1; i < n; i++)
        {
            if (arr[min] > arr[i])
            {
                min = i;
            }
        }
        var temp = arr[s];
        arr[s] = arr[min];
        arr[min] = temp;
        s++;
    }
}
