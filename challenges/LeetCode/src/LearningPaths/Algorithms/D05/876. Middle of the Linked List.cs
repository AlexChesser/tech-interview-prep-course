using System;
using System.Diagnostics;

namespace _876_Middle_of_the_Linked_List
{
    public class Solution
    {
        public ListNode MiddleNode_wrong_but_close(ListNode head)
        {
            ListNode mid = head;
            ListNode seek = head;
            int counter = 0;
            int target = 0;
            while (seek.next != null)
            {
                counter++;
                if (counter >= target)
                {
                    mid = seek;
                    target *= 2;
                }
                seek = seek.next;
            }
            return mid;
        }


        public ListNode MiddleNode(ListNode head)
        {
            ListNode mid = head;
            ListNode seek = head;
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

    }
}