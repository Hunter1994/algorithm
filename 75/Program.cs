// See https://aka.ms/new-console-template for more information
int[] items = { 1, 2, 3, 4, 5 };
int max = 9;
int num = 0;

op(0, num);
Console.WriteLine(num);

void op(int idx, int n)
{
    if (idx == items.Length || n == max)
    {
        if (n > num) num = n;
        return;
    }

    op(idx + 1, n);
    if (n + items[idx] <= max)
    {
        op(idx + 1, n + items[idx]);
    }
}
