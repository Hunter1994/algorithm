
int maxW = 0;
int[] items = new int[] { 5, 5, 2 };
int w = 10;
f(0, 0, items, items.Length, w);
Console.WriteLine(maxW);

void f(int i, int cw, int[] items, int n, int w)
{
    if (cw == w || i == n)
    {
        if (cw > maxW) maxW = cw;
        return;
    }
    f(i + 1, cw, items, n, w);
    if (items[i] + cw <= w)
        f(i + 1, items[i] + cw, items, n, w);
}