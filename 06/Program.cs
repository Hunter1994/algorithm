// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[] { 1, 2, 3, 4, 4, 5 };
var index = Find(arr, 4);
Console.WriteLine(index);

int Find(int[] arr, int value)
{
	var low = 0;
	var high = arr.Length - 1;
	while (low <= high)
	{
		var mid = low + (high - low) / 2;
		//if(arr[mid]==value)return mid;
		if (value >= arr[mid])
		{
			low = mid + 1;
		}
		else
		{
			high = mid - 1;
		}
	}
	if (high < arr.Length && arr[high] == value) return high;
	return -1;
}
