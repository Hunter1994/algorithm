// See https://aka.ms/new-console-template for more information
var arr = new int[] { 2, 2, 4, 6, 3 };
int w = 9;
bool[][] states = new bool[arr.Length][];
for (int i = 0; i < arr.Length; i++)
{
    states[i] = new bool[w + 1];
}
states[0][0] = true;
if (arr[0] <= w)
{
    states[0][arr[0]] = true;
}

for (int i = 1; i < arr.Length; i++)
{
    for (int j = 0; j <= w; j++)
    {
        if (states[i - 1][j])
            states[i][j] = states[i - 1][j];
    }
    for (int k = 0; k <= w - arr[i]; k++)
    {
        if (states[i - 1][k])
        {
            states[i][k + arr[i]] = true;
        }
    }
}
for (int i = w; i >= 0; i--)
{
    if (states[arr.Length - 1][i])
    {
        Console.WriteLine(i);
        return;
    }
}