var arr = new int[] { -1, 7, 5, 19, 8, 4, 1, 20, 13, 16 };
var n = arr.Length - 1;
BuildHeep();
Sort();


void BuildHeep()
{
    var index = n / 2;
    for (int i = index; i > 0; i--)
    {
        Heapify(i, n);
    }
}

void Heapify(int index, int maxIndex)
{
    var p = index;
    while (p <= maxIndex)
    {
        var maxp = p;
        if (maxp * 2 <= maxIndex && arr[maxp * 2] > arr[p])
        {
            maxp = maxp * 2;
        }
        if (p * 2 + 1 <= maxIndex && arr[p * 2 + 1] > arr[maxp])
        {
            maxp = p * 2 + 1;
        }
        if (maxp == p) break;
        (arr[p], arr[maxp]) = (arr[maxp], arr[p]);
        p = maxp;
    }
}

void Sort()
{
    var index = arr.Length - 1;
    while (index > 0)
    {
        Console.WriteLine(arr[1]);
        (arr[1], arr[index]) = (arr[index], arr[1]);
        index--;

        Heapify(1, index);
    }

}