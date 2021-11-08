using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]
        [TestCase("2,3,1,1,4", 2)]
        [TestCase("2,3,0,1,4", 2)]

        /*
        Example 1:

Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [2,3,0,1,4]
Output: 2
        */
        public void _45_JumpGameII(string arr, int expected)
        {
            var s = new _45_JumpGameII.Solution();
            int result = s.Jump(arr.ToIntArray());
            Assert.AreEqual(expected, result);
        }
    }
}