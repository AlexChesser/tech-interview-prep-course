using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {



        // Input: l1 = [1,2,4], l2 = [1,3,4]
        // Output: [1,1,2,3,4,4]

        // Example 2:

        // Input: l1 = [], l2 = []
        // Output: []

        // Example 3:

        // Input: l1 = [], l2 = [0]
        // Output: [0]



        [Test]
        // [TestCase("1,2,4", "1,3,4", "1,1,2,3,4,4")]
        [TestCase("", "", "")]
        [TestCase("", "0", "0")]
        public void _21_MergeTwoSortedLists(string arr, string arr2, string expected)
        {
            var s = new _21_MergeTwoSortedLists.Solution();
            ListNode result = s.MergeTwoLists(ListNode.Create(arr), ListNode.Create(arr2));
            Assert.AreEqual(expected, ListNode.AsString(result));
        }
    }
}