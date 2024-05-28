// See https://aka.ms/new-console-template for more information
CircularQueue circularQueue = new(5);
System.Console.WriteLine(circularQueue.enqueue(1));
System.Console.WriteLine(circularQueue.enqueue(2));
System.Console.WriteLine(circularQueue.enqueue(3));
System.Console.WriteLine(circularQueue.enqueue(4));
System.Console.WriteLine(circularQueue.enqueue(5));
System.Console.WriteLine(circularQueue.dequeue());
System.Console.WriteLine(circularQueue.enqueue(6));


public class CircularQueue
{
    private int[] arr;
    private int n;
    private int tail;
    private int head;
    public CircularQueue(int capacity)
    {
        arr = new int[capacity];
        n = capacity;
    }
    public bool enqueue(int item)
    {
        var p = (tail + 1) % n;
        if (p == head) return false;
        arr[tail] = item;
        tail = p;
        return true;
    }
    public int? dequeue()
    {
        if (head == tail) return null;
        var data = arr[head];
        head = (head + 1) % n;
        return data;
    }
}