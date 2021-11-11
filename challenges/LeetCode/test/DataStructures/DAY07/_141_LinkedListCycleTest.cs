using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("foo", "bar")]
        public void _141_LinkedListCycle(string arr, string expected)
        {
            var s = new _141_LinkedListCycle.Solution();
            //int result = s.LengthOfLongestSubstring(arr);
            Assert.Inconclusive("could write this test easily enough but it is late and I'm a bit tired :)");
        }
    }
}