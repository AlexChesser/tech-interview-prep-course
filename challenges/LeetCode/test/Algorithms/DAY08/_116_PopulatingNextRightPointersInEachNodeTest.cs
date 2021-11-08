using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {

        [Test]
        [TestCase("foo", "bar")]
        public void _116_PopulatingNextRightPointersinEachNode(string arr, string expected)
        {
            var s = new _116_PopulatingNextRightPointersinEachNode.Solution();
            //int result = s.LengthOfLongestSubstring(arr);
            //Assert.AreEqual(expected, result);
            Assert.Inconclusive("omg this test will take ages to write!");
        }
    }
}