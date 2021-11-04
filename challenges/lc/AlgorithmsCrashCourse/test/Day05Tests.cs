using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day05Tests : TestTemplate
    {



        [Test]
        [TestCase("1,2,3,4,5", 2, "1,2,3,5")]
        [TestCase("1,2,3,4,5", 3, "1,2,4,5")]
        [TestCase("1", 1, "")]
        [TestCase("1,2", 1, "1")]
        [TestCase("1,2", 2, "2")]
        [TestCase("1,2,3", 3, "2,3")]
        public void _19_Remove_Nth_Node_From_End_of_List(string arr, int target, string expected)
        {
            var s = new _19_Remove_Nth_Node_From_End_of_List.Solution();
            ListNode head = ListNode.Create(arr);
            ListNode result = s.RemoveNthFromEnd(head, target);
            Assert.AreEqual(expected, ListNode.AsString(result));
        }

        [Test]

        [TestCase("1,2,3,4,5", "3,4,5")]
        [TestCase("1,2,3,4,5,6", "4,5,6")]
        public void _876_Middle_of_the_Linked_List(string arr, string expected)
        {
            var s = new _876_Middle_of_the_Linked_List.Solution();
            ListNode head = ListNode.Create(arr);
            Debug.WriteLine(ListNode.AsString(head));
            var result = s.MiddleNode(head);
            Assert.AreEqual(expected, ListNode.AsString(result));
        }

    }
}