// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[3][];
arr[0] = new int[] { 1, 1, 5 };
arr[1] = new int[] { 2, 1, 3 };
arr[2] = new int[] { 5, 1, 6 };

// arr[0] = new int[] { 1, 3, 5, 9 };
// arr[1] = new int[] { 2, 1, 3, 4 };
// arr[2] = new int[] { 5, 2, 6, 7 };
// arr[3] = new int[] { 6, 8, 4, 3 };

int n = arr.Length;
int m = int.MaxValue;
// f(0, 0, 0);
// Console.WriteLine(m);
f2();
var mem = new int[3][];
for (int i = 0; i < 3; i++)
{
    mem[i] = new int[3];
}
var res = f3(2, 2);
Console.WriteLine(res);
void f(int i, int j, int dist)
{
    if (i == n || j == n)
    {
        if (dist < m) m = dist;
        return;
    }
    if (i < n)
    {
        f(i + 1, j, arr[i][j] + dist);
    }
    if (j < n)
    {
        f(i, j + 1, arr[i][j] + dist);
    }
}


void f2()
{
    int[][] state = new int[3][];
    for (int i = 0; i < 3; i++)
    {
        state[i] = new int[3];
    }

    int sum = 0;
    for (int i = 0; i < 3; i++)
    {
        sum += arr[i][0];
        state[i][0] = sum;
    }
    sum = 0;
    for (int i = 0; i < 3; i++)
    {
        sum += arr[0][i];
        state[0][i] = sum;
    }

    for (int i = 1; i < 3; i++)
    {
        for (int j = 1; j < 3; j++)
        {
            state[i][j] = Math.Min(state[i - 1][j] + arr[i][j], state[i][j - 1] + arr[i][j]);
        }
    }

    Console.WriteLine(state[2][2]);

}



int f3(int i, int j)
{
    if (i == 0 && j == 0) return arr[0][0];
    if (mem[i][j] > 0) return mem[i][j];
    int minLeft = 0;
    if (j - 1 >= 0)
    {
        minLeft = f3(i, j - 1);
    }
    int minUp = 0;
    if (i - 1 >= 0)
    {
        minUp = f3(i - 1, j);
    }
    int p = arr[i][j] + Math.Min(minLeft, minUp);
    mem[i][j] = p;
    return p;
}