// See https://aka.ms/new-console-template for more information
string n = "abcasdwwer";
string m = "casd";

var index = aa(n, m);
Console.WriteLine(index);
int aa(string n, string m)
{
    for (int i = 0; i < n.Length - m.Length + 1; i++)
    {
        var trueNum = 0;
        for (int k = 0; k < m.Length; k++)
        {
            if (n[i + trueNum] == m[k])
            {
                trueNum++;
            }
            else break;
        }
        if (trueNum == m.Length) return i;
        else trueNum = 0;
    }
    return -1;
}

