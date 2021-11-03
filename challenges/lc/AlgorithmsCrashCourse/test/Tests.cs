using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Tests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [OneTimeTearDown]
        public void OneTimeTearDow()
        {
            Trace.Flush();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5, 4)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void _278_FirstBadVersion(int n, int bad)
        {
            var s = new _278_FirstBadVersion.Solution();
            s.BadVersion = bad;
            int result = s.FirstBadVersion(n);
            Assert.AreEqual(result, bad, $"target {result} expected {bad}");
        }

        [Test]
        [TestCase("1,3,5,6", 5, 2)]
        [TestCase("1,3,5,6", 2, 1)]
        [TestCase("1,3,5,6", 7, 4)]
        [TestCase("1,3,5,6", 0, 0)]
        [TestCase("1", 0, 0)]
        public void _35_SearchInsertPosition(string arr, int target, int expected)
        {
            var s = new _35_SearchInsertPosition.Solution();
            int[] haystack = arr.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            int result = s.SearchInsert(haystack, target);
            Assert.AreEqual(result, expected, $"target {target} expected {expected}");
        }

        [Test]
        [TestCase("-1,0,3,5,9,12", 9, 4)]
        [TestCase("-1,0,3,5,9,12", 2, -1)]
        public void _704_BinarySearch(string arr, int target, int expected)
        {
            var s = new _704_BinarySearch.Solution();
            int[] haystack = arr.Split(",")
                .Select(i => int.Parse(i))
                .ToArray();
            int result = s.Search(haystack, target);
            Assert.AreEqual(result, expected, $"target {target} expected {expected}");
        }

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