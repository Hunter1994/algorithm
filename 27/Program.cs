// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] items = new int[] { 2, 3, 4 }; // 物品的重量
int[] value = { 5, 3, 6 }; // 物品的价值
int n = 3; // 物品个数
int w = 7; // 背包承受的最大重量

int[][] states = new int[n][];
for (int i = 0; i < n; i++)
{
    states[i] = new int[w + 1];
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < w + 1; j++)
    {
        states[i][j] = -1;
    }
}

states[0][0] = 0;
if (items[0] <= w)
{
    states[0][items[0]] = value[0];
}

for (int i = 1; i < n; i++)
{
    for (int j = 0; j <= w; j++)
    {
        if (states[i - 1][j] >= 0)
            states[i][j] = states[i - 1][j];
    }
    for (int k = 0; k <= w - items[i]; k++)
    {
        if (states[i - 1][k] >= 0)
        {
            states[i][k + items[i]] = states[i - 1][k] + value[i];
        }
    }
}
int maxvalue = -1;
for (int i = w; i >= 0; i--)
{
    if (states[n - 1][i] > maxvalue)
    {
        maxvalue = states[n - 1][i];
    }
}
Console.WriteLine(maxvalue);