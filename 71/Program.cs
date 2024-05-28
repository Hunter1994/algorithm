string b = "cbacbacba";
int m = b.Length;
int[] buffix = new int[m];
bool[] preffix = new bool[m];
for (int i = 0; i < m - 1; i++)
{
    int j = i;
    int k = 0;
    while (j >= 0 && b[j] == b[m - 1 - k])
    {
        j--;
        k++;
        buffix[k] = j + 1;
    }
    if (j == -1) preffix[k] = true;
}

var a = "";