using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("1,2,6,3,4,5,6", 6, "1,2,3,4,5")]
        [TestCase("", 1, "")]
        [TestCase("7,7,7,7", 7, "")]
        [TestCase("1,2,2,1", 2, "1,1")]
        public void _203_RemoveLinkedListElements(string arr, int target, string expected)
        {
            var s = new _203_RemoveLinkedListElements.Solution();
            var result = s.RemoveElements(ListNode.Create(arr), target);
            Assert.AreEqual(expected, ListNode.AsString(result));
        }
    }
}