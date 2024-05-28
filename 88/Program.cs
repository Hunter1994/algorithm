// See https://aka.ms/new-console-template for more information
DynamicArray dynamicArray = new DynamicArray();
dynamicArray.Add(7);
dynamicArray.Add(3);
dynamicArray.Add(1);
dynamicArray.Add(2);
dynamicArray.Add(5);
dynamicArray.Add(4);
dynamicArray.Add(6);

// dynamicArray.Add(1);
// dynamicArray.Add(2);
// dynamicArray.Add(5);
dynamicArray.Print();
dynamicArray.Delete(7);
dynamicArray.Print();
dynamicArray.Update(5, 1);
dynamicArray.Print();
DynamicArray dynamicArray2 = new DynamicArray();
dynamicArray2.Add(1);
dynamicArray2.Add(5);
dynamicArray2.Add(10);

var datas = merge(dynamicArray.arr, dynamicArray.count, dynamicArray2.arr, dynamicArray2.count);
Print();
void Print()
{
    for (int i = 0; i < datas.Length; i++)
    {
        Console.Write(datas[i] + " ");
    }
    Console.WriteLine();
}

int[] merge(int[] a, int an, int[] b, int bn)
{
    var temp = new int[an + bn];
    int j = 0, k = 0;
    int n = 0;
    while (j < an && k < bn)
    {
        if (a[j] <= b[k])
        {
            temp[n++] = a[j++];
        }
        else
        {
            temp[n++] = b[k++];
        }
    }
    while (j < an)
    {
        temp[n++] = a[j++];
    }
    while (k < bn)
    {

        temp[n++] = b[k++];
    }
    return temp;
}

public class DynamicArray
{
    public int[] arr;
    int n = 0;
    public int count = 0;
    public DynamicArray()
    {
        arr = new int[10];
        n = 10;
    }

    public void Add(int i)
    {
        if (count >= n) return;
        int k = 0;
        for (; k < count; k++)
        {
            if (arr[k] > i)
            {
                break;
            }
        }
        for (int j = count - 1; j >= k; j--)
        {
            arr[j + 1] = arr[j];
        }
        arr[k] = i;
        count++;
    }
    public void Delete(int i)
    {
        if (count == 0) return;
        int k = count - 1;
        for (; k >= 0; k--)
        {
            if (arr[k] == i)
            {
                break;
            }
        }
        if (k == -1) return;
        for (int m = k; m < count; m++)
        {
            arr[m] = arr[m + 1];
        }
        count--;
    }

    public void Update(int idx, int i)
    {
        if (idx < 0 || idx > count - 1) return;
        for (int m = idx; m < count; m++)
        {
            arr[m] = arr[m + 1];
        }
        count--;
        Add(i);
    }

    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}