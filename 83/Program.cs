// See https://aka.ms/new-console-template for more information

BitMap b = new BitMap(100);
b.Set(16);
b.Set(50);
b.Set(100);
Console.WriteLine(b.Exists(50));
Console.WriteLine(b.Exists(100));
Console.WriteLine(b.Exists(1));

public class BitMap
{
    public int n;
    public char[] chars;
    public BitMap(int n)
    {
        this.n = n;
        chars = new char[n / 16 + 1];
    }

    public void Set(int i)
    {
        if (i > n) return;
        var k = i / 16;
        var k2 = i % 16;
        var c = (char)(1 << k2);
        chars[k] = c;
    }

    public bool Exists(int i)
    {
        var k = i / 16;
        var k2 = i % 16;
        var c = (char)(1 << k2);

        return (chars[k] & c) != 0;
    }

}

