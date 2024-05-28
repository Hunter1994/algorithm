// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string n = "ababaaaabaaaeabac";
string m = "aaabaaa";
var res = bmp();
Console.WriteLine(res);

int bmp()
{
    var next = GetNext(m);
    int j = 0;
    for (int i = 0; i < n.Length; i++)
    {
        if (j > 0 && n[i] != m[j])
        {
            j = next[j - 1] + 1;
        }
        if (n[i] == m[j])
        {
            ++j;
        }
        if (j == m.Length)
        {
            return i - m.Length + 1;
        }
    }

    return -1;
}



int[] GetNext(string m)
{
    var next = new int[m.Length];
    next[0] = -1;
    int k = -1;
    for (int i = 1; i < m.Length; i++)
    {
        while (k != -1 && m[k + 1] != m[i])
        {
            k = next[k];
        }
        if (m[k + 1] == m[i])
        {
            k++;
        }
        next[i] = k;
    }
    return next;
}