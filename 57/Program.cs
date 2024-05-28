// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
var arr = new string[] { "D", "a", "F", "B", "c", "A", "z" };
aa1();

for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();
void aa1()
{
    var temp = new string[arr.Length];
    var index = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (Regex.IsMatch(arr[i], "[a-z]"))
        {
            temp[index++] = arr[i];
        }
    }
    for (int i = 0; i < arr.Length; i++)
    {
        if (Regex.IsMatch(arr[i], "[A-Z]"))
        {
            temp[index++] = arr[i];
        }
    }
    for (int i = 0; i < temp.Length; i++)
    {
        arr[i] = temp[i];
    }
}
