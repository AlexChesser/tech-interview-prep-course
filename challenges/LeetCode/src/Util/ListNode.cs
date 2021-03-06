
using System.Linq;
/**
* Definition for singly-linked list. */
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode Create(string commaSepartatedValues)
    {
        if (commaSepartatedValues.Length == 0)
        {
            return null;
        }
        int[] values = commaSepartatedValues
            .Split(",")
            .Select(c => int.Parse(c))
            .ToArray();
        ListNode head = new ListNode(values[0]);
        ListNode tmp = head;
        for (int i = 1; i < values.Length; i++)
        {
            tmp.next = new ListNode(values[i]);
            tmp = tmp.next;
        }
        return head;
    }

    public static string AsString(ListNode head)
    {
        if (head == null)
        {
            return "";
        }
        string output = head.val.ToString();
        ListNode tmp = head.next;
        while (tmp != null)
        {
            output += "," + tmp.val.ToString();
            tmp = tmp.next;
        }
        return output;
    }
}
