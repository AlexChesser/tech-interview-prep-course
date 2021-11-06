using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {

        [Test]
        [TestCase("foo", "bar")]
        public void _617_MergeTwoBinaryTrees(string arr, string expected)
        {
            var s = new _617_MergeTwoBinaryTrees.Solution();
            //int result = s.LengthOfLongestSubstring(arr);
            //Assert.AreEqual(expected, result);
            Assert.Pass();
        }
    }
}