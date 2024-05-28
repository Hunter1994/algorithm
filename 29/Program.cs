// See https://aka.ms/new-console-template for more information

var item = new int[] { 50, 20, 30 };
var w = 100;
var n = 3;

var states = new bool[n][];
for (int i = 0; i < n; i++)
{
    states[i] = new bool[w * 3 + 1];
}
states[0][0] = true;
if (item[0] <= w)
    states[0][item[0]] = true;

for (int i = 1; i < n; i++)
{
    for (int j = 0; j < w * 3 + 1; j++)
    {
        if (states[i - 1][j])
            states[i][j] = true;
    }
    for (int k = 0; k < w * 3 + 1 - item[i]; k++)
    {
        if (states[i - 1][k])
        {
            states[i][k + item[i]] = true;
        }
    }
}

int m = w;
for (; m < w * 3 + 1; m++)
{
    if (states[n - 1][m]) break;
}
if (m == w * 3 + 1)
{
    Console.WriteLine("未找到");
    return;
}

for (int p = n - 1; p >= 1; p--)
{
    if (m - item[p] >= 0 && states[p - 1][m - item[p]])
    {
        Console.WriteLine(item[p]);
        m -= item[p];
    }
}
if (m != 0) Console.WriteLine(item[0]);