using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("[1,2,2,1]", "[2,2]", "2,2")]
        [TestCase("[4,9,5]", "[9,4,9,8,4]", "4,9")]
        public void _350_IntersectionofTwoArraysII(string arr, string arr2, string expected)
        {
            var s = new _350_IntersectionofTwoArraysII.Solution();
            int[] result = s.Intersect(arr.ToIntArray(), arr2.ToIntArray());
            Array.Sort(result);
            Assert.AreEqual(expected, result.CommaJoin());
        }
    }
}