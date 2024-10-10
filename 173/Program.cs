Solution solution=new Solution ();
var res=solution.FindLucky([2,2,2,3,3]);
Console.WriteLine(res);

public class Solution {
    public int FindLucky(int[] arr) {
        int[] temp=new int[501];
        for (int i = 0; i < arr.Length; i++)
        {
            temp[arr[i]]++;
        }
        
        for (int i = 500; i >=1; i--)
        {
            if(temp[i]==i)return i;
        }
return -1;
    }
}