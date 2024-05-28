// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var arr = new int[] { 2, 2, 4, 6, 3 };
int w = 9;
var states = new bool[w + 1];
states[0] = true;
if (arr[0] <= w)
{
    states[arr[0]] = true;
}

for (int i = 1; i < arr.Length; i++)
{
    for (int j = w - arr[i]; j >= 0; j--)
    {
        if (states[j])
        {
            states[j + arr[i]] = true;
        }
    }
}
for (int i = states.Length - 1; i >= 0; i--)
{
    if (states[i])
    {
        Console.WriteLine(i);
        return;
    }
}