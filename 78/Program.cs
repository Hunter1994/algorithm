// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
int[][] arr = new int[3][];
arr[0] = new int[3] { 1, 3, 5 };
arr[1] = new int[3] { 2, 1, 3 };
arr[2] = new int[3] { 5, 2, 6 };

var max = int.MaxValue;
f(0, 0, 1);
t();

int[][] m = new int[3][];
for (int i = 0; i < m.Length; i++)
{
    m[i] = new int[3];
}


var aaa = minDist(2, 2);
Console.WriteLine("aaa=" + aaa);
int minDist(int i, int j)
{
    if (i == 0 && j == 0)
    {
        return arr[0][0];
    }
    if (m[i][j] > 0) return m[i][j];

    int a1 = int.MaxValue;
    int a2 = int.MaxValue;
    if (i > 0)
        a1 = minDist(i - 1, j);
    if (j > 0)
        a2 = minDist(i, j - 1);

    m[i][j] = arr[i][j] + Math.Min(a1, a2);
    return m[i][j];
}

void t()
{
    var tb = new int[3][];
    for (int i = 0; i < tb.Length; i++)
    {
        tb[i] = new int[3];
    }
    int num = 0;
    int num1 = 0;
    for (int i = 0; i < 3; i++)
    {
        num += arr[0][i];
        tb[0][i] = num; //初始化列

        num1 += arr[i][0];
        tb[i][0] = num1;//初始化行
    }

    for (int i = 1; i < 3; i++)
    {
        for (int j = 1; j < 3; j++)
        {
            tb[i][j] = Math.Min(arr[i][j] + tb[i - 1][j], arr[i][j] + tb[i][j - 1]);
        }
    }
    Console.WriteLine(tb[2][2]);
}


void f(int d, int r, int n)
{
    if (d == 2 && r == 2)
    {
        if (n < max) max = n;
        return;
    }
    if (d < 2)
        f(d + 1, r, n + arr[d + 1][r]);
    if (r < 2)
        f(d, r + 1, n + arr[d][r + 1]);
}

Console.WriteLine(max);