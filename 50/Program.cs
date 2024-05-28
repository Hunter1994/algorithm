// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Console.WriteLine(f(6));
Console.WriteLine(f2(6));
int f(int n)
{
    if (n == 1) return 1;
    if (n == 2) return 2;
    return f(n - 1) + f(n - 2);
}

int f2(int n)
{
    if (n == 1) return 1;
    if (n == 2) return 2;
    int ret = 0;
    int pre = 2;
    int prepre = 1;
    for (int i = 3; i <= n; i++)
    {
        ret = pre + prepre;
        prepre = pre;
        pre = ret;
    }
    return ret;
}