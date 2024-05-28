
MyCircularDeque obj = new MyCircularDeque(5);
obj.InsertLast(7);
obj.InsertFront(0);
obj.GetFront();
obj.InsertLast(3);
obj.GetFront();
obj.InsertFront(9);
obj.GetRear();


public class MyCircularDeque
{
    private int[] _arr;
    private int start = 0;
    private int end = 0;
    private int n;
    public MyCircularDeque(int k)
    {
        n = k + 1;
        _arr = new int[n];
    }

    public bool InsertFront(int value)
    {
        if ((end + 1) % n == start)
        {
            return false;
        }
        if (start == end)
        {
            _arr[end++] = value;
        }
        else
        {
            var index = (start + n - 1) % n;
            _arr[index] = value;
            start = index;
        }
        return true;
    }

    public bool InsertLast(int value)
    {
        var index = (end + 1) % n;
        if (index == start)
        {
            return false;
        }
        _arr[end] = value;
        end = index;
        return true;
    }

    public bool DeleteFront()
    {
        if (start == end) return false;
        start = (start + 1) % n;
        return true;
    }

    public bool DeleteLast()
    {
        if (start == end) return false;
        end = (end + n - 1) % n;
        return true;
    }

    public int GetFront()
    {
        if (start == end) return -1;
        return _arr[start];
    }

    public int GetRear()
    {
        if (start == end) return -1;
        return _arr[(end + n - 1) % n];
    }

    public bool IsEmpty()
    {
        return start == end;
    }

    public bool IsFull()
    {
        return (end + 1) % n == start;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */