using NUnit.Framework;
using _704_BinarySearch;
using _278_FirstBadVersion;
using _35_SearchInsertPosition;
using System.Linq;
using System.Diagnostics;
using System;

namespace test
{
    public class Tests
    {
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
    }
}