int[] items = new int[] { 10, 2, 3, 4 };
int maxW = 8;

bool[][] ds = new bool[items.Length][];
for (int i = 0; i < ds.Length; i++)
{
    ds[i] = new bool[maxW + 1];
}

ds[0][0] = true;
if (items[0] <= maxW)
{
    ds[0][items[0]] = true;
}

for (int i = 1; i < items.Length; i++)
{
    for (int j = 0; j < ds[i].Length; j++)
    {
        if (ds[i - 1][j])
            ds[i][j] = ds[i - 1][j];
    }
    for (int j = 0; j < ds[i].Length; j++)
    {
        if (ds[i - 1][j])
        {
            if (j + items[i] <= maxW)
            {
                ds[i][j + items[i]] = true;
            }
        }
    }
}

for (int i = maxW; i >= 0; i--)
{
    if (ds[items.Length - 1][i])
    {
        Console.WriteLine(i);
        break;
    }
}

