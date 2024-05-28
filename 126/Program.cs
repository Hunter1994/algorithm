var arr = new int[] { 2, 4, 3, 1, 5, 6 };
var n = arr.Length;
var res = sort(0, n - 1);
for (int i = 0; i < n; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();
Console.WriteLine(res);


int sort(int s, int e)
{
    if (s >= e) return 0;
    var q = (s + e) / 2;
    var r1 = sort(s, q);
    var r2 = sort(q + 1, e);
    var lx1 = merge(s, e, q);
    return r1 + r2 + lx1;
}

int merge(int s, int e, int q)
{
    var temp = new int[e - s + 1];
    int index = 0;
    int i = s, j = q + 1;
    var lx = 0;
    while (i <= q && j <= e)
    {
        if (arr[i] < arr[j])
        {
            temp[index++] = arr[i++];
        }
        else
        {
            lx += (q - i) + 1;
            temp[index++] = arr[j++];
        }
    }

    while (i <= q)
    {
        temp[index++] = arr[i++];
    }

    while (j <= e)
    {
        temp[index++] = arr[j++];
    }

    for (int k = 0; k < index; k++)
    {
        arr[k + s] = temp[k];
    }
    return lx;
}

