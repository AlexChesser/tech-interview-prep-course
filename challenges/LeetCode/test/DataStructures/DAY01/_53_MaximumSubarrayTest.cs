using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {
        [Test]
        [TestCase("-2,1,-3,4,-1,2,1,-5,4", 6)]
        [TestCase("1", 1)]
        [TestCase("5,4,-1,7,8", 23)]
        public void _53_MaximumSubarray(string arr, string expected)
        {
            var s = new _53_MaximumSubarray.Solution();
            int result = s.MaxSubArray(arr.ToIntArray());
            Assert.AreEqual(expected, result);
        }
    }
}