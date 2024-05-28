// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("Hello, World!");

BitArray array = new BitArray(101);
array.Set(1, true);
array.Set(10, true);
array.Set(100, true);

Console.WriteLine(array.Get(1));
Console.WriteLine(array.Get(10));
Console.WriteLine(array.Get(100));
Console.WriteLine(array.Get(11));



BitMap bitMap = new BitMap(100);
bitMap.set(1);
bitMap.set(10);
bitMap.set(100);



public class BitMap
{
    private char[] chars;
    private int nbits;
    public BitMap(int nbits)
    {
        this.nbits = nbits;
        chars = new char[nbits / 16 + 1];
    }

    public void set(int k)
    {
        int byteIndex = k / 16;
        int bitIndex = k % 16;
        chars[byteIndex] = (char)(chars[byteIndex] | (1 << bitIndex));
    }
    public bool get(int k)
    {
        int byteIndex = k / 16;
        int bitIndex = k % 16;
        return (char)(chars[byteIndex] & (1 << bitIndex)) != 0;
    }

}