// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ArrayStack arrayStack = new ArrayStack(5);
System.Console.WriteLine(arrayStack.Push("1"));
System.Console.WriteLine(arrayStack.Push("2"));
System.Console.WriteLine(arrayStack.Push("3"));
System.Console.WriteLine(arrayStack.Push("4"));
System.Console.WriteLine(arrayStack.Push("5"));
System.Console.WriteLine(arrayStack.Push("6"));
System.Console.WriteLine(arrayStack.Pop());
System.Console.WriteLine(arrayStack.Pop());
System.Console.WriteLine(arrayStack.Pop());
System.Console.WriteLine(arrayStack.Pop());
System.Console.WriteLine(arrayStack.Pop());
System.Console.WriteLine(arrayStack.Pop());
System.Console.WriteLine(arrayStack.Pop());


public class ArrayStack
{
    public string[] arr;
    public int n;
    public int count;
    public ArrayStack(int length)
    {
        arr = new string[length];
        n = length;
        count = 0;
    }

    public bool Push(string i)
    {
        if (count == n)
        {
            var temp = new string[n * 2];
            for (int k = 0; k < n; k++)
            {
                temp[k] = arr[k];
            }
            arr = temp;
        };
        arr[count++] = i;
        return true;
    }
    public string Pop()
    {
        if (count == 0) return null;
        return arr[--count];
    }

}