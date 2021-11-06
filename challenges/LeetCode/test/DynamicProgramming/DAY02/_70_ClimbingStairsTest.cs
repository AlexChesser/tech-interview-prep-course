using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        public void _70_ClimbingStairsDP(int arr, int expected)
        {
            var s = new _70_ClimbingStairsDP.Solution();
            int result = s.ClimbStairs(arr);
            Assert.AreEqual(expected, result);
        }
    }
}