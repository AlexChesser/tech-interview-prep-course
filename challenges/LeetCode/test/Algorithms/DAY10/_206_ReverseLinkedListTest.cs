using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {

        [Test]
        [TestCase("1,2,3,4,5", "5,4,3,2,1")]
        [TestCase("1,2", "2,1")]
        [TestCase("", "")]
        public void _206_ReverseLinkedList(string arr, string expected)
        {
            var s = new _206_ReverseLinkedList.Solution();
            ListNode result = s.ReverseList(ListNode.Create(arr));
            Assert.AreEqual(expected, ListNode.AsString(result));
        }
    }
}