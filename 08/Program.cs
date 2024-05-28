// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

SkipList sl=new SkipList();

sl.Insert(1);
sl.Insert(5);
sl.Insert(4);
sl.Print();
public class SkipList
{
	public Node head=new Node(maxlevel);
	public const int maxlevel=16;
	public int level=1;
	public Random r=new Random();
	public Node Find(int value)
	{
		var p=head;
		for(int i=level-1;i<=0;i++)
		{
			if(p.forwards[i]!=null&&p.forwards[i].data<value)
			{
				p=p.forwards[i];
			}
		}
		if(p.forwards[0]!=null&&p.forwards[0].data==value)return p.forwards[0];
		else return null;
	}
	
	public void Insert(int value)
	{
		var l=head.forwards[0]==null?1:Random();
		if(l>level)
		{
			l=++level;
		}
		Node newNode = new Node(l);
        newNode.data = value;
		var p=head;
		for(int i=level-1;i>=0;--i)
		{
			while(p.forwards[i]!=null&&p.forwards[i].data<value)
			{
				p=p.forwards[i];
			}
			if(l>i)
			{
				if (p.forwards[i] == null) {
                    p.forwards[i] = newNode;
                } else {
                    Node next = p.forwards[i];
                    p.forwards[i] = newNode;
                    newNode.forwards[i] = next;
                }
			}
		}
	}
	
	public int Random()
	{
		int count=1;
		for(int i=0;i<maxlevel;i++)
		{
			if (r.Next() % 2 == 1) {
                level++;
            }
		}
		return count;
	}
	public void Print()
	{
		var p=head;
		while(p.forwards[0]!=null)
		{
			Console.WriteLine(p.forwards[0].data);
			p=p.forwards[0];
		}
	}
	
	
}

public class Node
{
	public int data;
	public Node[] forwards;
	public Node(int level)
	{
		forwards=new Node[level];
	}
}