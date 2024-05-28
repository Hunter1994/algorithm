// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string n = "aaaaaaabaaaa";
string m = "baa";
int[] bs = new int[256];

void generateBc(string n, string m, int[] bs)
{
    for (int i = 0; i < bs.Length; i++)
    {
        bs[i] = -1;
    }

    for (int i = 0; i < m.Length; i++)
    {
        var acc = (int)m[i];
        bs[acc] = i;
    }
}

int bm()
{
    int i = 0;
    while (i < n.Length - m.Length)
    {
        int j = m.Length - 1;
        for (; j >= 0; j--)
        {
            if (n[i + j] != m[j]) break;
        }
        if (j < 0) return i;
        var x = 0;
        var y = 0;
        x = j - bs[(int)n[i + j]];

        if (j < m.Length - 1)
        {
            y = moveByGs(j);
        }
        i = i + Math.Max(x, y);
    }
    return -1;
}

int[] suffix = new int[m.Length];
bool[] prefix = new bool[m.Length];
void generateGS(int[] suffix, bool[] prefix)
{
    for (int i = 0; i < m.Length; i++)
    {
        suffix[i] = -1;
        prefix[i] = false;
    }
    for (int i = 0; i < m.Length - 1; i++)
    {
        var j = i;
        var k = 0;
        while (j >= 0 && m[j] == m[m.Length - 1 - k])
        {
            j--;
            k++;
            suffix[k] = j + 1;
        }
        if (j == -1) prefix[k] = true;
    }
}

int moveByGs(int j)
{
    var k = m.Length - 1 - j;
    if (suffix[k] != -1) return j - suffix[k] + 1;
    for (int r = j + 2; r < m.Length - 1; r++)
    {
        if (prefix[m.Length - r] == true) return r;
    }
    return m.Length;
}
generateBc(n, m, bs);
generateGS(suffix, prefix);
var res = bm();
Console.WriteLine(res);