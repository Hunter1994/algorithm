var str1 = "mitcmu";
var str2 = "mtacnu";

var data = new int[str1.Length][];
for (int i = 0; i < data.Length; i++)
{
    data[i] = new int[str2.Length];
}

for (int i = 0; i < str1.Length; i++)
{
    if (str1[i] == str2[0]) data[i][0] = i;
    else if (i != 0) data[i][0] = data[i - 1][0] + 1;
    else data[i][0] = 1;
}

for (int i = 0; i < str2.Length; i++)
{
    if (str1[0] == str2[i]) data[0][i] = i;
    else if (i != 0) data[0][i] = data[0][i - 1] + 1;
    else data[0][i] = 1;
}


for (int i = 1; i < str1.Length; i++)
{
    for (int j = 1; j < str2.Length; j++)
    {
        var cost = 0;
        if (str1[i] != str2[j])
        {
            cost++;
        }
        data[i][j] = Math.Min(Math.Min(data[i - 1][j] + 1, data[i][j - 1] + 1), data[i - 1][j - 1] + cost);
    }
}

Console.WriteLine(data[str1.Length - 1][str2.Length - 1]);
