// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
var arr = new string[] { "13344445555", "13003158320", "13600003333" };

ListNode list1 = new ListNode(5);
// ListNode list2 = new ListNode(2, list1);
// ListNode list3 = new ListNode(1, list2);


ListNode l1 = new ListNode(4);
ListNode l2 = new ListNode(2, l1);
ListNode l3 = new ListNode(1, l2);

Solution solution = new Solution();
var a = solution.MergeTwoLists(list1, l3);
while (a != null)
{
    Console.WriteLine(a.val);
    a = a.next;
}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        ListNode result = list1;
        ListNode list1NextPro = null;
        //ListNode minNode = list1;
        ListNode list1Next = list1;
        ListNode list2Next = list2;
        while (list1Next != null && list2Next != null)
        {
            if (list1Next.val >= list2Next.val)
            {
                var list2NextTemp = list2Next.next;
                if (result.val >= list2Next.val)
                {
                    list2Next.next = result;
                    result = list2Next;
                    if (list1NextPro == null)
                        list1NextPro = list2Next;
                }
                else
                {
                    list1NextPro.next = list2Next;
                    list2Next.next = list1Next;
                    list1NextPro = list2Next;
                }
                list2Next = list2NextTemp;
            }
            else
            {
                if (list1Next.next == null && list2Next != null)
                {
                    var list2NextTemp = list2Next.next;
                    list1Next.next = list2Next;
                    list2Next.next = null;
                    list2Next = list2NextTemp;
                }

                list1NextPro = list1Next;
                list1Next = list1Next.next;
            }
        }

        return result;

    }
}