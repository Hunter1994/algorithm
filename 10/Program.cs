// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

TreeNode r=new TreeNode();
r.Insert(33);
r.Insert(16);
r.Insert(50);
r.Insert(13);
r.Insert(18);
r.Insert(34);
r.Insert(58);

r.Delete(16);
r.Print();
// var res= r.Get(34);
// Console.WriteLine(res.Data);
public class TreeNode
{
	private Node root;
	public Node Get(int data)
	{
		var p=root;
		while(p!=null)
		{
			if(data>p.Data)
			{
				p=p.Right;
			}
			else if(data<p.Data)
			{
				p=p.Left;
			}
			else return p;
		}
		return null;
	}
	
	public void Insert(int data)
	{
		if(root==null)
		{
			root=new Node(data);
			return;
		}
		var p=root;
		while(p!=null)
		{
			if(data>=p.Data)
			{
				if(p.Right==null)
				{
					p.Right=new Node(data);
					return;
				}else
				p=p.Right;
			}
			else if(data<p.Data)
			{
				if(p.Left==null)
				{
					p.Left=new Node(data);
					return;
				}
				else
				p=p.Left;
			}
		}
	}
	
	public void Delete(int data)
	{
		if(root==null)return;
		var p=root;
		Node pp=null;
		while(p!=null&&p.Data!=data)
		{
			pp=p;
			if(data>p.Data)
			{
				p=p.Right;
			}
			else
			{
				p=p.Left;
			}
		}
		if(p==null)return;
		
		if(p.Left!=null&&p.Right!=null)
		{
			Node minP=p.Right;
			Node minPP=p;
			while(minP.Left!=null)
			{
				minPP=minP;
				minP=minP.Left;
			}
			p.Data=minP.Data;
			p=minP;
			pp=minPP;
		}
		
		Node child;
		if(p.Left!=null) child=p.Left;
		else if(p.Right!=null) child=p.Right;
		else child=null;
		
		if(pp==null)root=child;
		else if (pp.Left==p)pp.Left=child;
		else pp.Right=child;

	}
	
	public void Print()
	{

		if(root==null)return;
		InPrint(root);
		
	}
	public void PrePrint(Node node)
	{
		if(node==null)return;
		Console.WriteLine(node.Data);
		PrePrint(node.Left);
		PrePrint(node.Right);
	}
	
	public void InPrint(Node node)
	{
		if(node==null)return;
		InPrint(node.Left);
		Console.WriteLine(node.Data);
		InPrint(node.Right);
	}
	
	
}


public class Node
{
	public int Data{get;set;}
	public Node Left{get;set;}
	public Node Right{get;set;}
	public Node(int data)
	{
		this.Data=data;
	}
}