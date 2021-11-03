using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day02Tests : TestTemplate
    {
        [Test]
        [TestCase("-4,-1,0,3,10", "0,1,9,16,100")]
        [TestCase("-7,-3,2,3,11", "4,9,9,49,121")]
        public void _977_SquaresofaSortedArray(string arr, string expected)
        {
            var s = new _977_SquaresofaSortedArray.Solution();
            int[] haystack = arr.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            int[] result = s.SortedSquares(haystack);
            Assert.AreEqual(expected, string.Join(",", result), $"records did not match");
        }

        [Test]
        [TestCase("1,2,3,4,5,6,7", 3, "5,6,7,1,2,3,4")]
        [TestCase("-1,-100,3,99", 2, "3,99,-1,-100")]
        public void _189_RotateArray(string arr, int k, string expected)
        {
            var s = new _189_RotateArray.Solution();
            int[] haystack = arr.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            s.Rotate(haystack, k);
            Assert.AreEqual(expected, string.Join(",", haystack), $"shifting {arr} {k} times gives {expected} got { string.Join(",", haystack)}");
        }

    }
}