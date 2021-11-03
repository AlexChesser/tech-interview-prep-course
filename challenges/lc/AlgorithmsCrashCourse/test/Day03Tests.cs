using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day03Tests : TestTemplate
    {
        [Test]
        [TestCase("0,1,0,3,12", "1,3,12,0,0")]
        [TestCase("0", "0")]
        public void _283_MoveZeroes(string arr, string expected)
        {
            var s = new _283_MoveZeroes.Solution();
            int[] haystack = arr.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            s.MoveZeroes(haystack);
            Assert.AreEqual(expected, string.Join(",", haystack));
        }

        [Test]
        [TestCase("2,7,11,15", 9, "1,2")]
        [TestCase("2,3,4", 6, "1,3")]
        [TestCase("-1,0", -1, "1,2")]
        public void _167_TwoSum_Sorted(string arr, int target, string expected)
        {
            var s = new _167_TwoSum_Sorted.Solution();
            int[] haystack = arr.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            s.TwoSum(haystack, target);
            Assert.AreEqual(expected, string.Join(",", haystack));
        }

    }
}