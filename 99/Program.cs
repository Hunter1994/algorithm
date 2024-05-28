uint a = 65535;
uint aaa3 = a * a;
uint aaa1 = (a + 1) * (a + 1);
uint aaa4 = aaa3 + 1;
uint aaa5 = aaa4 + 1;
uint aaa6 = aaa5 + 10;

Solution s = new Solution();


var aaa = s.MySqrt(2147395599);
Console.WriteLine(aaa);

public class Solution
{
    public int MySqrt(int x)
    {
        if (x == 0) return 0;
        if (x == 1) return 1;

        uint i = 0;
        uint j = 1 << 16;
        while (true)
        {
            if (i > j) return -1;
            uint m = (j + i) / 2;
            uint v = m * m;
            if (v > x)
            {
                j = m;
            }
            else if (v <= x)
            {
                i = m;
            }

            if (j - i <= 1)
            {
                return (int)i;
            }
        }

    }

}