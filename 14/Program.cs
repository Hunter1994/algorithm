// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Dictionary<int, int> dic = new Dictionary<int, int>();

var aaaa = f(40);
Console.WriteLine(aaaa);

int f(int n)
{
    if (dic.TryGetValue(n, out var v))
    {
        return v;
    }

    if (n <= 2) return 1;
    var res = f(n - 1) + f(n - 2);
    dic[n] = res;
    return res;
}
