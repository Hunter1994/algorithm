var arr = new int[2][];
arr[0] = [1, 3];
arr[1] = [2, 1];
// arr[0] = [1, 3, 5, 9];
// arr[1] = [2, 1, 3, 4];
// arr[2] = [5, 2, 6, 7];
// arr[3] = [6, 8, 4, 3];
var item = new List<KeyValuePair<string, string>>();
var res = f(0, 0);
Console.WriteLine(res);
Console.WriteLine($"({3},{3})");
print("", $"({1},{1})");
void print(string s, string e)
{
    var prev = item.Where(r => r.Key == e).FirstOrDefault();
    if (prev.Key == null)
        return;
    Console.WriteLine(prev.Value);
    print(s, prev.Value);
}

int f(int i, int j)
{
    var p = arr.Length;
    var status = new int[p][];
    for (int m = 0; m < status.Length; m++)
    {
        status[m] = new int[p];
    }
    status[0][0] = arr[i][j];
    for (int x = 1; x < p; x++)
    {
        status[0][x] = status[0][0] + arr[i][j + x];
        status[x][0] = status[0][0] + arr[i + x][j];
    }

    for (int f = 1; f < p; f++)
    {
        for (int n = 1; n < p; n++)
        {
            var s = status[f][n - 1] + arr[f][n];
            if (status[f - 1][n] + arr[f][n] < status[f][n - 1] + arr[f][n])
            {
                s = status[f - 1][n] + arr[f][n];
                item.Add(new KeyValuePair<string, string>($"({f},{n})", $"({f - 1},{n})"));
            }
            else
            {
                item.Add(new KeyValuePair<string, string>($"({f},{n})", $"({f},{n - 1})"));
            }

            status[f][n] = s;
        }
    }
    return status[p - 1][p - 1];
}






