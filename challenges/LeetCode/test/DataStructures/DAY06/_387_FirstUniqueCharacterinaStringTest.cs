using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        [TestCase("aabb", -1)]


        /*
        Example 1:

Input: s = "leetcode"
Output: 0

Example 2:

Input: s = "loveleetcode"
Output: 2

Example 3:

Input: s = "aabb"
Output: -1

        */
        public void _387_FirstUniqueCharacterinaString(string arr, int expected)
        {
            var s = new _387_FirstUniqueCharacterinaString.Solution();
            int result = s.FirstUniqChar(arr);
            Assert.AreEqual(expected, result);
        }
    }
}