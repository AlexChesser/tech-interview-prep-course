using System;
using System.Diagnostics;

namespace _19_Remove_Nth_Node_From_End_of_List
{
    public class Solution
    {

        public ListNode RemoveNthFromEnd_better(ListNode head, int n)
        {
            // note that this is actually a touch slower (though that could be natural variance on the server)
            var left = head;
            var right = head;

            while (right != null)
            {
                right = right.next;
                // from the comments / discussion, this seemed to be a really novel solution.
                if (n-- < 0) left = left.next;
            }

            if (n == 0) head = head.next;
            else left.next = left.next.next;

            return head;
        }



        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode fast = head;
            ListNode slow = head;
            ListNode previous = null;
            int fastSteps = 0;
            int slowSteps = 0;
            while (fast != null)
            {
                // Debug.WriteLine($"fastSteps {fastSteps} value {fast.val}");
                if (fastSteps - slowSteps == n)
                {
                    previous = slow;
                    slow = slow.next;
                    slowSteps++;
                }
                if (fast.next == null)
                {
                    // Debug.WriteLine($"at the end {fast.val}");
                    // Debug.WriteLine($"removing value {slow.val}");
                    // Debug.WriteLine($"previous is {previous.val}");
                    if (fastSteps + 1 == n)
                    {
                        head = head.next;
                    }
                    if (previous != null && previous.next != null && previous.next.next != null)
                    {
                        // Debug.WriteLine($"Skipping {previous.next.val} setting to {previous.next.next.val}");
                        previous.next = previous.next.next;
                    }
                    else if (previous != null && previous.next != null)
                    {
                        previous.next = null;
                    }
                    slow = null;
                    return head;
                }
                fast = fast.next;
                fastSteps++;
            }
            return head;
        }
    }
}