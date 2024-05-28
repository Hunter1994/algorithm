// See https://aka.ms/new-console-template for more information
var arr = new int[] { 10, 99, 100, 1, 80, 70, 4, 1, 10, 99 };
var r = new int[arr.Length];
var max = 0;
for (int i = 0; i < arr.Length; i++)
{
    if (max < arr[i])
    {
        max = arr[i];
    }
}
var c = new int[max + 1];
for (int i = 0; i < arr.Length; i++)
{
    c[arr[i]]++;
}
for (int i = 1; i < c.Length; i++)
{
    c[i] = c[i - 1] + c[i];
}

for (int i = arr.Length - 1; i >= 0; i--)
{
    r[--c[arr[i]]] = arr[i];
}
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = r[i];
}
for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();