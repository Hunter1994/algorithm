// See https://aka.ms/new-console-template for more information

char[] pattern = { 'a', 'b', '*', 'd' };
char[] taxt = { 'a', 'b', 'c', 'c', 'd' };
var result = false;

rmatch(0, 0);

Console.WriteLine(result);

void rmatch(int pi, int ti)
{
    if (result) return;
    if (ti == taxt.Length && pi == pattern.Length)
    {
        result = true;
        return;
    }

    if (pattern[pi] == '*')
    {
        for (int i = 0; i < taxt.Length - ti; i++)
        {
            rmatch(pi + 1, ti + i);
        }
    }
    else if (pattern[pi] == taxt[ti])
    {
        rmatch(pi + 1, ti + 1);
    }


}



