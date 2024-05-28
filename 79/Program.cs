// See https://aka.ms/new-console-template for more information
string a = "mitcmu";
string b = "mtacnu";
int an = a.Length;
int bn = b.Length;
int minDist = int.MaxValue;
op(0, 0, 0);
Console.WriteLine(minDist);
op2();
op3();

void op3()
{
    int[][] minDists = new int[an][];
    for (int i = 0; i < an; i++)
    {
        minDists[i] = new int[bn];
    }

    for (int i = 0; i < an; i++)
    {
        if (a[0] == b[i]) minDists[0][i] = i;
        else if (i != 0) minDists[0][i] = minDists[0][i - 1];
        else minDists[0][i] = 0;

        if (b[0] == a[i]) minDists[i][0] = 1;
        else if (i != 0) minDists[i][0] = minDists[i - 1][0];
        else minDists[i][0] = 0;
    }

    for (int i = 1; i < an; i++)
    {
        for (int j = 1; j < bn; j++)
        {
            if (a[i] == b[j])
            {
                minDists[i][j] = Math.Max(Math.Max(minDists[i][j - 1], minDists[i - 1][j]), minDists[i - 1][j - 1] + 1);
            }
            else
            {
                minDists[i][j] = Math.Max(Math.Max(minDists[i][j - 1], minDists[i - 1][j]), minDists[i - 1][j - 1]);
            }
        }
    }

    Console.WriteLine(minDists[an - 1][bn - 1]);
}

void op2()
{
    int[][] minDists = new int[an][];
    for (int i = 0; i < an; i++)
    {
        minDists[i] = new int[bn];
    }

    for (int i = 0; i < an; i++)
    {
        if (a[0] == b[i]) minDists[0][i] = i;
        else if (i != 0) minDists[0][i] = minDists[0][i - 1] + 1;
        else minDists[0][i] = 1;

        if (b[0] == a[i]) minDists[i][0] = i;
        else if (i != 0) minDists[i][0] = minDists[i - 1][0] + 1;
        else minDists[i][0] = 1;
    }

    for (int i = 1; i < an; i++)
    {
        for (int j = 1; j < bn; j++)
        {
            if (a[i] == b[j])
            {
                minDists[i][j] = Math.Min(Math.Min(minDists[i][j - 1] + 1, minDists[i - 1][j] + 1), minDists[i - 1][j - 1]);
            }
            else
            {
                minDists[i][j] = Math.Min(Math.Min(minDists[i][j - 1] + 1, minDists[i - 1][j] + 1), minDists[i - 1][j - 1] + 1);
            }
        }
    }

    Console.WriteLine(minDists[an - 1][bn - 1]);
}



void op(int i, int j, int edist)
{
    if (i == an || j == bn)
    {
        if (i < an) edist += an - i;
        if (j < bn) edist += bn - j;
        if (minDist > edist) minDist = edist;
        return;
    }

    if (a[i] == b[j])
    {
        op(i + 1, j + 1, edist);
    }
    else
    {
        op(i + 1, j, edist + 1);
        op(i, j + 1, edist + 1);
        op(i + 1, j + 1, edist + 1);
    }
}