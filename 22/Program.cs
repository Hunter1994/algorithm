// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Pattern p = new Pattern("12*5?", 5);
var res = p.match("12456", 5);
Console.WriteLine(res);

public class Pattern
{
    public bool matched = false;
    public string pattern;
    public int plen;
    public Pattern(string p, int l)
    {
        this.pattern = p;
        plen = l;
    }

    public bool match(string text, int tlen)
    {
        rmatch(0, 0, text, tlen);
        return matched;
    }

    public void rmatch(int ti, int pj, string text, int tlen)
    {
        if (matched) return;
        if (pj == plen)
        {
            if (ti == tlen) matched = true;
            return;
        }
        if (pattern[pj] == '*')
        {
            for (int i = 0; i < tlen - ti; i++)
            {
                rmatch(ti + i, pj + 1, text, tlen);
            }
        }
        else if (pattern[pj] == '?')
        {
            rmatch(ti, pj + 1, text, tlen);
            rmatch(ti + 1, pj + 1, text, tlen);
        }
        else if (text[ti] == pattern[pj])
        {
            rmatch(ti + 1, pj + 1, text, tlen);
        }
    }

}