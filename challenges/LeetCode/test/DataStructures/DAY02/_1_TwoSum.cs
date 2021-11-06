using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("2,7,11,15", 9, "0,1")]
        [TestCase("3,2,4", 6, "1,2")]
        [TestCase("3,3", 6, "0,1")]
        public void _1_TwoSum(string arr, int target, string expected)
        {
            var s = new _1_TwoSum.Solution();
            int[] value = arr.Split(",").Select(c => int.Parse(c)).ToArray();
            var result = s.TwoSum(value, target);
            Assert.AreEqual(expected, string.Join(",", result));
            Assert.Pass();
        }
    }
}