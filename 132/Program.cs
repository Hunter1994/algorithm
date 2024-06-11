//2, 3, 5, 7
int[] arr = [2, 9, 3, 6, 5, 1, 7];

var data = new int[arr.Length];

data[0] = 1;
var num = 1;
for (int i = 1; i < arr.Length; i++)
{
    data[i] = 1;
    if (i + 1 < arr.Length && arr[i] < arr[i + 1])
    {
        num++;
    }
    else
    {
        for (int j = 0; j < i; j++)
        {
            if (arr[j] < arr[i])
            {
                data[i] = Math.Max(data[j] + 1, data[i]);
            }
        }

        num = Math.Max(num, data[i]);
    }
}
Console.WriteLine(num);