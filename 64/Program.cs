// See https://aka.ms/new-console-template for more information
Node a = new Node("A");
Node b = new Node("B");
Node c = new Node("C");
Node d = new Node("D");
a.Left = b;
a.Right = c;
b.Left = d;

PreOrder(a);
Console.WriteLine();
InOrder(a);
Console.WriteLine();
PostOrder(a);
Console.WriteLine();

void PreOrder(Node node)
{
    if (node == null) return;
    Console.Write(node.Data + " ");
    PreOrder(node.Left);
    PreOrder(node.Right);
}
void InOrder(Node node)
{
    if (node == null) return;
    InOrder(node.Left);
    Console.Write(node.Data + " ");
    InOrder(node.Right);
}
void PostOrder(Node node)
{
    if (node == null) return;
    PostOrder(node.Left);
    PostOrder(node.Right);
    Console.Write(node.Data + " ");
}
public class Node
{
    public string Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public Node(string data)
    {
        Data = data;
    }

}
