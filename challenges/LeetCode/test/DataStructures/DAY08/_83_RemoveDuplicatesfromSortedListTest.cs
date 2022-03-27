using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("1,1,2", "1,2")]
        [TestCase("1,1,2,3,3", "1,2,3")]
        [TestCase("1,1,2,2,2,2,3,3", "1,2,3")]
        public void _83_RemoveDuplicatesfromSortedList(string arr, string expected)
        {
            var s = new _83_RemoveDuplicatesfromSortedList.Solution();
            ListNode result = s.DeleteDuplicates(ListNode.Create(arr));
            Assert.AreEqual(expected, ListNode.AsString(result));
        }
    }
}