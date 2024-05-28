
var aaaaa = getNexts("abcabcc".ToArray(), 7);
string a = "aaaaaaaabaaaaaaaa";
string b = "baaa";
var n = a.Length;
var m = b.Length;
int SIZE = 256;

var index = kmp(a.ToArray(), n, b.ToArray(), m);
Console.WriteLine(index);




int kmp(char[] a, int n, char[] b, int m)
{
    var nexts = getNexts(b, m);
    int j = 0;
    for (int i = 0; i < n; i++)
    {
        while (j > 0 && a[i] != b[j])
        {
            j = nexts[j - 1] + 1;
        }
        if (a[i] == b[j])
        {
            j++;
        }
        if (j == m) return i - m + 1;
    }
    return -1;
}

int[] getNexts(char[] b, int m)
{
    var next = new int[m];
    next[0] = -1;
    var k = -1;
    for (int i = 1; i < m; i++)
    {
        while (k != -1 && b[k + 1] != b[i])
        {
            k = next[k];
        }
        if (b[k + 1] == b[i])
        {
            k++;
        }
        next[i] = k;
    }
    return next;
}



void generateGS(char[] b, int m, int[] suffix, bool[] prefix)
{
    for (int i = 0; i < m - 1; i++)
    {
        suffix[i] = -1;
        prefix[i] = false;
    }

    for (int i = 0; i < m - 1; i++)
    {
        int j = i;
        int k = 0;
        while (j >= 0 && b[j] == b[m - 1 - k])
        {
            j--;
            k++;
            suffix[k] = j + 1;
        }
        if (j == -1) prefix[k] = true;

    }

}

void generateBC(char[] b, int m, int[] bc)
{
    for (int i = 0; i < SIZE; i++)
    {
        bc[i] = -1;
    }
    for (int i = 0; i < m; i++)
    {
        bc[(int)b[i]] = i;
    }
}
int bm(char[] a, int n, char[] b, int m)
{
    var bc = new int[SIZE];
    var suffix = new int[m];
    var prefix = new bool[m];
    generateBC(b, m, bc);
    generateGS(b, m, suffix, prefix);
    int i = 0;
    while (i <= n - m)
    {
        int j = m - 1;
        for (; j >= 0; j--)
        {
            if (a[i + j] != b[j]) break;
        }
        if (j < 0) return i;
        var xi = bc[(int)a[i + j]];
        var x = j - xi;
        int y = 0;
        if (j < m - 1)
        {
            y = moveByGS(j, b, m, suffix, prefix);
        }
        i = i + Math.Max(x, y);
    }
    return -1;
}

int moveByGS(int j, char[] b, int m, int[] suffix, bool[] prefix)
{
    var k = m - 1 - j;
    if (suffix[k] != -1) return j - suffix[k] + 1;
    for (int i = j + 2; i < m - 1; i++)
    {
        if (prefix[m - i]) return i;
    }
    return m;
}