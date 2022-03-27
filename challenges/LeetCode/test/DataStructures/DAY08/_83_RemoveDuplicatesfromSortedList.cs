namespace _83_RemoveDuplicatesfromSortedList
{
    public class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode sentinel = new(-1, head);
            while (head != null)
            {
                if (head.next != null && head.next.val == head.val)
                {
                    head.next = head.next.next;
                }
                else
                {
                    head = head.next;
                }
            }
            return sentinel.next;
        }
    }
}