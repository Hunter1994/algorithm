// See https://aka.ms/new-console-template for more information

var arr = new int[] { 8, 8, 8, 11, 19, 23, 27, 27, 27, 33, 45, 55, 67, 98, 98 };

var res = Find(8);
Console.WriteLine(res);
res = Find(27);
Console.WriteLine(res);
res = Find(98);
Console.WriteLine(res);
res = Find(9);
Console.WriteLine(res);
int Find(int value)
{
    var low = 0;
    var high = arr.Length - 1;
    while (low <= high)
    {
        var mid = low + (high - low >> 1);
        //查找最后一个小于等于给定值的元素
        if (arr[mid] > value)
        {
            high = mid - 1;
        }
        else
        {
            if (mid >= arr.Length - 1 || arr[mid + 1] > value) return mid;
            low = mid + 1;
        }
    }
    return -1;
}



bool Find3(int value)
{
    return Find2(value, 0, arr.Length - 1);
}

bool Find2(int value, int low, int high)
{
    if (low > high) return false;
    var mid = (low + high) / 2;
    if (arr[mid] == value) return true;
    else if (value > arr[mid])
    {
        return Find2(value, mid + 1, high);
    }
    else
    {
        return Find2(value, low, mid - 1);
    }
}