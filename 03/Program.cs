// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var arr = new int[] { 2, 5, 3, 0, 2, 3, 0, 3 };
Sort(arr);
for (int i = 0; i < arr.Length; i++)
{
	Console.WriteLine(arr[i]);
}
void Sort(int[] arr)
{
	var max = arr[0];
	for (int i = 1; i < arr.Length; i++)
	{
		if (arr[i] > max)
		{
			max = arr[i];
		}
	}

	var c = new int[max + 1];
	for (int j = 0; j < arr.Length; j++)
	{
		c[arr[j]]++;
	}


	for (int j = 1; j < c.Length; j++)
	{
		c[j] = c[j - 1] + c[j];
	}

	var r = new int[arr.Length];
	for (int j = arr.Length - 1; j >= 0; j--)
	{
		r[c[arr[j]] - 1] = arr[j];
		c[arr[j]]--;
	}
	for (int i = 0; i < arr.Length; i++)
	{
		arr[i] = r[i];
	}

}