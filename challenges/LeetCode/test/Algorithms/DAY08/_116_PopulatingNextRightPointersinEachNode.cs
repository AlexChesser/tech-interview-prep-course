namespace _116_PopulatingNextRightPointersinEachNode
{
    /*
    // Definition for a Node.
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

Input: root = [1,2,3,4,5,6,7]
Output: [1,#,2,3,#,4,5,6,7,#]
Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

Example 2:

Input: root = []
Output: []


    */

    public class Solution
    {
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }
            Node leftMost = root;

            while (leftMost.left != null)
            {
                Node head = leftMost;
                while (head != null)
                {
                    head.left.next = head.right;
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }
                    head = head.next;
                }
                leftMost = leftMost.left;
            }
            return root;
        }
    }
}
