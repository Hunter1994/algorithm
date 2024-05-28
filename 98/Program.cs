// See https://aka.ms/new-console-template for more information
var arr = new int[] { 1, 2, 3, 4, 4, 5, 6, 6 };
var a = find(4, 0, arr.Length - 1);
Console.WriteLine(a);
a = find(1, 0, arr.Length - 1);
Console.WriteLine(a);
a = find(6, 0, arr.Length - 1);
Console.WriteLine(a);
a = find(60, 0, arr.Length - 1);
Console.WriteLine(a);

int find(int i, int p, int q)
{
    if (p > q) return -1;
    var mid = (p + q) / 2;
    if (arr[mid] == i)
    {
        var j = mid;
        while (j <= arr.Length - 1 && arr[mid] == arr[j])
        {
            j++;
        }
        if (j > arr.Length - 1) return -1;
        else return j;
    }
    if (arr[mid] > i)
    {
        return find(i, p, mid - 1);
    }
    else
    {
        return find(i, mid + 1, q);
    }
}
