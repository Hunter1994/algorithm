// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var g=new Node("G");
var f=new Node("F");
var e=new Node("E");
var d=new Node("D");
var c=new Node("C",f,g);
var b=new Node("B",d,e);
var a=new Node("A",b,c);

PrePrint(a);
Console.WriteLine();
InPrint(a);
Console.WriteLine();
PostPrint(a);
void PrePrint(Node n)
{
	if(n==null)return;
	Console.Write(n.Data);
	PrePrint(n.Left);
	PrePrint(n.Rigth);
}

void InPrint(Node n)
{
	if(n==null)return;
	InPrint(n.Left);
	Console.Write(n.Data);
	InPrint(n.Rigth);
}
void PostPrint(Node n)
{
	if(n==null)return;
	PostPrint(n.Left);
	PostPrint(n.Rigth);
	Console.Write(n.Data);
}

void LevelPrint(Node n)
{
	if(n==null)return;
	Console.Write(n.Data);
	if(n.Left!=null)
	Console.Write(n.Left.Data);
	if(n.Rigth!=null)
	Console.Write(n.Rigth.Data);

	PrePrint(n.Left);
	PrePrint(n.Rigth);
}

public class Node
{
	public string Data{get;set;}
	public Node Left{get;set;}
	public Node Rigth{get;set;}
	public Node(string data,Node left=null,Node rigth=null)
	{
		Data=data;
		Left=left;
		Rigth=rigth;
	}
}