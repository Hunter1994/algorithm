var str1 = "abccd";
Console.WriteLine(IndexOf("a"));
Console.WriteLine(IndexOf("ab"));
Console.WriteLine(IndexOf("abc"));
Console.WriteLine(IndexOf("cc"));
Console.WriteLine(IndexOf("d"));
Console.WriteLine(IndexOf("dd"));

int IndexOf(string str)
{
    int index = 0;
    while (index <= str1.Length - str.Length)
    {
        int i = 0;
        for (; i < str.Length; i++)
        {
            if (str[i] != str1[index + i])
            {
                break;
            }
        }
        if (i == str.Length) return index;
        index++;
    }
    return -1;
}