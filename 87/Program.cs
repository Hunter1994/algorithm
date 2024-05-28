// See https://aka.ms/new-console-template for more information
using System.Text;

string input = "Hello, Murmur Hash!";
uint hashValue = MurmurHash.Murmur2(input);
Console.WriteLine($"Murmur2 Hash of '{input}': {hashValue}");


public class MurmurHash
{
    private const uint Seed = 0; // 可以根据需要设置不同的种子值

    public static uint Murmur2(string text)
    {
        return Murmur2(Encoding.UTF8.GetBytes(text));
    }

    public static uint Murmur2(byte[] data)
    {
        const uint m = 0x5bd1e995;
        const int r = 24;

        int length = data.Length;
        uint h = Seed ^ (uint)length;

        int currentIndex = 0;

        while (length >= 4)
        {
            uint k = BitConverter.ToUInt32(data, currentIndex);
            k *= m;
            k ^= k >> r;
            k *= m;

            h *= m;
            h ^= k;

            currentIndex += 4;
            length -= 4;
        }

        switch (length)
        {
            case 3:
                h ^= (ushort)(data[currentIndex++] | data[currentIndex++] << 8);
                h ^= (uint)data[currentIndex] << 16;
                h *= m;
                break;
            case 2:
                h ^= (ushort)(data[currentIndex++] | data[currentIndex] << 8);
                h *= m;
                break;
            case 1:
                h ^= data[currentIndex];
                h *= m;
                break;
        }

        h ^= h >> 13;
        h *= m;
        h ^= h >> 15;

        return h;
    }
}