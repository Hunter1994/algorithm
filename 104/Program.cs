
Solution solution = new();

solution.ReverseString(new char[6] { 'H', 'a', 'n', 'n', 'a', 'h' });
public class Solution
{
    public void ReverseString(char[] s)
    {
        if (s.Length <= 1) return;
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            (s[i], s[j]) = (s[j], s[i]);
            // var temp = s[i];
            // s[i] = s[j];
            // s[j] = temp;
            i++;
            j--;
        }
    }
}