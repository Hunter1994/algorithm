// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] arr = { 2, 2, 4, 6, 3 };
int[] value = { 3, 4, 8, 9, 6 };
int maxV = 0;
int w = 9;
// var res = knapsack(arr, arr.Length, w);
//Console.WriteLine(res);
f(0, 0, 0);
Console.WriteLine(maxV);

var res = knapsack2(arr, value, arr.Length, w);
Console.WriteLine(res);

void f(int i, int cw, int cv)
{
    if (i == arr.Length || cw == w)
    {
        if (cv > maxV)
        {
            maxV = cv;
        }
        return;
    }

    f(i + 1, cw, cv);
    if (cw + arr[i] <= w)
    {
        f(i + 1, cw + arr[i], cv + value[i]);
    }
}

int knapsack2(int[] weigth, int[] v, int n, int w)
{
    var states = new int[n][];
    for (int i = 0; i < n; i++)
    {
        states[i] = new int[w + 1];
        for (int j = 0; j < states[i].Length; j++)
        {
            states[i][j] = -1;
        }
    }

    states[0][0] = 0;
    if (weigth[0] <= w)
        states[0][weigth[0]] = v[0];

    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j <= w; j++)
        {
            if (states[i - 1][j] >= 0) states[i][j] = states[i - 1][j];
        }

        for (int k = 0; k <= w - weigth[i]; k++)
        {
            if (states[i - 1][k] >= 0)
            {
                var a = states[i - 1][k] + v[i];
                if (a > states[i][k + weigth[i]])
                {
                    states[i][k + weigth[i]] = a;
                }
            }
        }
    }
    var max = 0;
    for (int i = w; i >= 0; i--)
    {
        if (states[n - 1][i] > max) return max = states[n - 1][i];
    }
    return max;
}

int knapsack(int[] weigth, int n, int w)
{
    var states = new bool[n][];
    for (int i = 0; i < n; i++)
    {
        states[i] = new bool[w + 1];
    }

    states[0][0] = true;
    if (weigth[0] <= w)
        states[0][weigth[0]] = true;

    for (int i = 1; i < n; i++)
    {
        for (int j = 0; j <= w; j++)
        {
            if (states[i - 1][j]) states[i][j] = states[i - 1][j];
        }

        for (int k = 0; k <= w - weigth[i]; k++)
        {
            if (states[i - 1][k]) states[i][k + weigth[i]] = true;
        }
    }

    for (int i = w; i >= 0; i--)
    {
        if (states[n - 1][i]) return i;
    }
    return 0;
}


