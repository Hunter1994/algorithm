int[] items = new int[] { 10, 2, 3, 40 };
int weightTotal = int.MinValue;
int maxW = 10;
f(0, 0);
Console.WriteLine(weightTotal);
void f(int w, int i)
{
    if (w <= maxW)
    {
        if (w > weightTotal)
            weightTotal = w;
    }
    if (i == items.Count()) return;

    f(items[i] + w, i + 1);
    f(items[i], i + 1);
}
