// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var weight = new int[] { 2, 3, 4 };
var price = new int[] { 5, 3, 6 };
var n = 3;
var w = 7;
var maxv = 0;
f(0, 0, 0);
Console.WriteLine(maxv);
void f(int i, int sw, int sv)
{
    if (w == sw || i == n)
    {
        if (sv > maxv) maxv = sv;
        return;
    }
    f(i + 1, sw, sv);
    if (sw + weight[i] <= w)
    {
        f(i + 1, sw + weight[i], sv + price[i]);
    }
}