// See https://aka.ms/new-console-template for more information
var arr = new int[] { 10, 99, 100, 1, 80, 70, 4, 1, 10, 99 };
var buketIndex = new int[10];
var buket = new int?[10][];
for (int i = 0; i < buket.Length; i++)
{
    buket[i] = new int?[arr.Length];
}
for (int k = 0; k < arr.Length; k++)
{
    if (arr[k] >= 0 && arr[k] <= 9)
    {
        buket[0][buketIndex[0]++] = arr[k];
    }
    else if (arr[k] >= 10 && arr[k] <= 19)
    {
        buket[1][buketIndex[1]++] = arr[k];
    }
    else if (arr[k] >= 20 && arr[k] <= 29)
    {
        buket[2][buketIndex[2]++] = arr[k];
    }
    else if (arr[k] >= 30 && arr[k] <= 39)
    {
        buket[3][buketIndex[3]++] = arr[k];
    }
    else if (arr[k] >= 40 && arr[k] <= 49)
    {
        buket[4][buketIndex[4]++] = arr[k];
    }
    else if (arr[k] >= 50 && arr[k] <= 59)
    {
        buket[5][buketIndex[5]++] = arr[k];
    }
    else if (arr[k] >= 60 && arr[k] <= 69)
    {
        buket[6][buketIndex[6]++] = arr[k];
    }
    else if (arr[k] >= 70 && arr[k] <= 79)
    {
        buket[7][buketIndex[7]++] = arr[k];
    }
    else if (arr[k] >= 80 && arr[k] <= 89)
    {
        buket[8][buketIndex[8]++] = arr[k];
    }
    else
    {
        buket[9][buketIndex[9]++] = arr[k];
    }
}

for (int i = 0; i < buket.Length; i++)
{
    quicksortc(buket[i], 0, buketIndex[i] - 1);
    for (int k = 0; k < buketIndex[i]; k++)
    {
        Console.Write(buket[i][k] + " ");
    }
}
Console.WriteLine();

void quicksortc(int?[] list, int q, int r)
{
    if (q >= r) return;
    var povit = positition(list, q, r);
    quicksortc(list, q, povit - 1);
    quicksortc(list, povit + 1, r);
}
int positition(int?[] list, int q, int r)
{
    var povit = list[r];
    int i = q;
    for (int j = q; j < r - 1; j++)
    {
        if (list[j] < povit)
        {
            var temp = list[j];
            list[j] = list[i];
            list[i++] = temp;
        }
    }
    list[r] = list[i];
    list[i] = povit;
    return i;
}

