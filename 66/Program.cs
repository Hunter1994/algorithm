// See https://aka.ms/new-console-template for more information

int[] data = new int[] { 0, 7, 5, 19, 8, 4, 1, 20, 13, 16 };
build(data);
sort();

for (int i = 1; i < data.Length; i++)
{
    Console.Write(data[i] + " ");
}
System.Console.WriteLine();
void build(int[] data)
{
    var p = (data.Length - 1) / 2;
    for (int ii = p; ii > 0; ii--)
    {
        var i = ii;
        while (true)
        {
            var maxpos = i;
            if (i * 2 <= data.Length && data[i] < data[i * 2]) maxpos = i * 2;
            if (i * 2 + 1 <= data.Length && data[maxpos] < data[i * 2 + 1]) maxpos = i * 2 + 1;
            if (maxpos == i) break;
            var temp = data[maxpos];
            data[maxpos] = data[maxpos / 2];
            data[maxpos / 2] = temp;
            i = maxpos;
        }
    }
}
void sort()
{
    var k = data.Length - 1;
    while (k > 0)
    {
        var temp = data[k];
        data[k] = data[1];
        data[1] = temp;
        k--;

        var i = 1;
        while (true)
        {
            var maxpos = i;
            if (i * 2 <= k && data[maxpos] < data[i * 2]) maxpos = i * 2;
            if (i * 2 + 1 <= k && data[maxpos] < data[i * 2 + 1]) maxpos = i * 2 + 1;
            if (maxpos == i) break;

            var temp1 = data[maxpos];
            data[maxpos] = data[maxpos / 2];
            data[maxpos / 2] = temp1;
            i = maxpos;
        }

    }

}















Heap h = new Heap(14);
h.Insert(33);
h.Insert(27);
h.Insert(21);
h.Insert(16);
h.Insert(13);
h.Insert(15);
h.Insert(19);
h.Insert(5);
h.Insert(6);
h.Insert(7);
h.Insert(8);
h.Insert(1);
h.Insert(2);
h.Insert(12);
h.DeleteMax();

for (int i = 1; i < h.data.Length; i++)
{
    Console.Write(h.data[i] + " ");
}
System.Console.WriteLine();
public class Heap
{
    public int[] data;
    private int count;
    private int n;
    public Heap(int n)
    {
        data = new int[n + 1];
        count = 0;
        this.n = n;
    }
    public void Insert(int i)
    {
        if (count >= n) return;
        count++;
        data[count] = i;
        var p = count;
        while (p / 2 > 0 && data[p] > data[p / 2])
        {
            var temp = data[p / 2];
            data[p / 2] = data[p];
            data[p] = temp;
            p = p / 2;
        }
    }

    public void DeleteMax()
    {
        if (count <= 0) return;
        data[1] = data[count];
        count--;
        var p = 1;
        while (true)
        {
            var maxpos = p;
            if (p * 2 <= count && data[maxpos] < data[p * 2]) maxpos = p * 2;
            if (p * 2 + 1 <= count && data[maxpos] < data[p * 2 + 1]) maxpos = p * 2 + 1;
            if (maxpos == p) break;
            var temp = data[maxpos];
            data[maxpos] = data[maxpos / 2];
            data[maxpos / 2] = temp;
            p = maxpos;
        }

    }


}
