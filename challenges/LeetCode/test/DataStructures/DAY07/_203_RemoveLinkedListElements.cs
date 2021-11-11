namespace _203_RemoveLinkedListElements
{
    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            ListNode sentinel = new ListNode(-1, head);
            ListNode prev = sentinel;
            ListNode curr = head;
            while (curr != null)
            {
                if (curr.val == val) prev.next = curr.next;
                else prev = curr;
                curr = curr.next;
            }
            return sentinel.next;
        }
    }
}