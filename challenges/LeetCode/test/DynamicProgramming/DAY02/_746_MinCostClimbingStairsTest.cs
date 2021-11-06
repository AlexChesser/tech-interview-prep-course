using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]
        [TestCase("10,15,20", 15)]
        [TestCase("1,100,1,1,1,100,1,1,100,1", 6)]
        public void _746_MinCostClimbingStairs(string arr, int expected)
        {
            var s = new _746_MinCostClimbingStairs.Solution();
            int result = s.MinCostClimbingStairs(arr.ToIntArray());
            Assert.AreEqual(expected, result);
        }
    }
}