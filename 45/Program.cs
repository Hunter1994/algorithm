// See https://aka.ms/new-console-template for more information

var n = new Node(1, null);
var n2 = new Node(2, n);
var n3 = new Node(3, n2);
var n4 = new Node(4, n3);
var n5 = new Node(5, n4);


Node p = null;
fz(n5);
while (p != null)
{
    Console.Write(p.Value + " ");
    p = p.Next;
}
System.Console.WriteLine();

Node fz(Node h)
{
    if (h == null) return null;
    var n = fz(h.Next);
    if (n != null)
    {
        h.Next = null;
        n.Next = h;
    }
    else
    {
        p = h;
    }
    return h;
}

public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
    public Node(int v, Node n)
    {
        Value = v;
        Next = n;
    }
}
