Console.WriteLine(Convert.ToBoolean(Convert.ToInt32("1")));
Console.WriteLine(Convert.ToBoolean(Convert.ToInt32("0")));

var s1 = "mitcmu";
var s2 = "mtacnu";


var maxlcs = new int[s1.Length][];
for (int i = 0; i < maxlcs.Length; i++)
{
    maxlcs[i] = new int[s2.Length];
}

for (int i = 0; i < s1.Length; i++)
{
    if (s1[i] == s2[0]) maxlcs[0][i] = 1;
    else if (i != 0)
        maxlcs[0][i] = maxlcs[0][i - 1];
    else maxlcs[0][i] = 0;
}
for (int i = 0; i < s2.Length; i++)
{
    if (s2[i] == s1[0]) maxlcs[i][0] = 1;
    else if (i != 0)
        maxlcs[i][0] = maxlcs[i - 1][0];
    else maxlcs[i][0] = 0;
}

for (int i = 1; i < s1.Length; i++)
{
    for (int j = 1; j < s2.Length; j++)
    {
        var cost = 0;
        if (s1[i] == s2[j]) cost = 1;
        var d = Math.Max(Math.Max(maxlcs[i - 1][j], maxlcs[i][j - 1]), maxlcs[i - 1][j - 1] + cost);
        maxlcs[i][j] = d;
    }
}

Console.WriteLine(maxlcs[s1.Length - 1][s2.Length - 1]);


