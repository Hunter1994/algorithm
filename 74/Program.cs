// See https://aka.ms/new-console-template for more information
var arr = new int[8];
bool result = false;

cel8queens(0);

void cel8queens(int row)
{
    if (row == 8)
    {
        print();
        result = true;
        return;
    }
    for (int column = 0; column < 8; column++)
    {
        if (result) return;
        if (isOk(row, column))
        {
            arr[row] = column;
            cel8queens(row + 1);
        }
    }
}

bool isOk(int row, int column)
{
    int leftColumn = column - 1;
    int upColumn = column + 1;
    for (int i = row - 1; i >= 0; i--)
    {
        if (arr[i] == column) return false;
        if (leftColumn >= 0 && arr[i] == leftColumn) return false;
        if (upColumn < 8 && arr[i] == upColumn) return false;
        leftColumn--;
        upColumn++;
    }
    return true;
}
void print()
{
    var str = "*";
    var str2 = "0";
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if (arr[i] == j)
            {
                Console.Write($"{str2}\t");
            }
            else
            {
                Console.Write($"{str}\t");
            }
        }
        Console.WriteLine();
    }
}