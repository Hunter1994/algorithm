int[][] arr = new int[4][];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = new int[4];
}

arr[1][2] = 1;
arr[1][3] = 1;
arr[3][2] = 1;

arr[2][1] = 1;
arr[3][1] = 1;
arr[2][3] = 1;


Node[] datas = new Node[4];
Node node2 = new Node() { Data = 2 };
Node node3 = new Node() { Data = 3 };
node2.Next = node3;
datas[1] = node2;


public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }
}
