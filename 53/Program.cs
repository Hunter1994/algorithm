// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[] { 6, 1, 2, 9, 1, 7, 5, 3 };

select();
for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i]);
}
Console.WriteLine();

void select()
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        var minIndex = i;
        for (int l = i; l < arr.Length - 1; l++)
        {
            if (arr[minIndex] > arr[l + 1])
            {
                minIndex = l + 1;
            }

        }
        var temp = arr[i];
        arr[i] = arr[minIndex];
        arr[minIndex] = temp;
    }

}

void insert()
{
    for (int i = 1; i < arr.Length; i++)
    {
        var value = arr[i];
        int k = i - 1;
        for (; k >= 0; k--)
        {
            if (value < arr[k])
            {
                arr[k + 1] = arr[k];
            }
            else break;
        }
        arr[k + 1] = value;
    }
}



void mp()
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int k = 0; k < arr.Length - 1 - i; k++)
        {
            if (arr[k] > arr[k + 1])
            {
                var temp = arr[k];
                arr[k] = arr[k + 1];
                arr[k + 1] = temp;
            }
        }
    }
}

