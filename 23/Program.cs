// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[] { 1, 10, 5, 6, 2, 10 };
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

foreach (var item in arr)
{
    Console.WriteLine(item);
}