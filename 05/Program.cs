// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr=new int[]{1,4,5,6,7,10,11};
var index=Find2(arr,10);
Console.WriteLine(index);
index=Find2(arr,1);
Console.WriteLine(index);
index=Find2(arr,11);
Console.WriteLine(index);
index=Find2(arr,0);
Console.WriteLine(index);

/*
int Find(int[] arr,int value)
{
	var low=0;
	var high=arr.Length-1;
	while(low<=high)
	{
		var mid= low+(high-low)/2;
		if(arr[mid]==value)return mid;
		else if(value<arr[mid])
		{
			high=mid-1;
		}
		else
		{
			low=mid+1;
		}
	}
	return -1;
}
*/
int Find2(int[] arr,int value)
{
	return Find(arr,0,arr.Length-1,value);
}
int Find(int[] arr,int low,int high,int value)
{
	if(low>high)return -1;
	var mid= low+(high-low)/2;
	if(arr[mid]==value)return mid;
	else if(value<arr[mid])
	{
		high=mid-1;
	}
	else
	{
		low=mid+1;
	}
 	return Find(arr,low,high,value);
}
