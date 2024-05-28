// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] arr = new int[8];
queens(0);
print();
void queens(int row)
{
    if (row == 8)
    {

        return;
    }
    for (int column = 0; column < 8; column++)
    {
        if (isok(row, column))
        {
            arr[row] = column;
            queens(++row);
        }
    }
}
bool isok(int row, int column)
{
    var laftup = column - 1;
    var rigthup = column + 1;
    for (int i = row - 1; i >= 0; i--)
    {
        if (arr[i] == column) return false;
        if (laftup >= 0 && arr[i] == laftup) return false;
        if (column < 8 && arr[i] == column) return false;
        laftup--;
        rigthup++;
    }
    return true;
}

void print()
{
    for (int i = 0; i < arr.Length; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (arr[i] == j)
            {
                if (j == 7) Console.WriteLine($"{"q",2}");
                else Console.Write($"{"q",2}");
            }
            else
            {
                if (j == 7) Console.WriteLine($"{"*",2}");
                else Console.Write($"{"*",2}");
            }
        }
    }
}