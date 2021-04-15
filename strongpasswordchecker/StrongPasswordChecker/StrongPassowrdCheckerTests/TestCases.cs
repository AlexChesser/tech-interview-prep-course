using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace StrongPassowrdCheckerTests
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        [DataRow("a", 5)]
        [DataRow("aA1", 3)]
        [DataRow("1337C0d3", 0)]
        [DataRow("aaAA11", 0)]
        [DataRow("aaaaaa", 2)]
        [DataRow("aaaaaA", 1)]
        [DataRow("aaaaaA", 1)]
        [DataRow("aaaAAA111", 3)]
        [DataRow("ABABABABABABABABABAB1", 2)]
        [DataRow("bbaaaaaaaaaaaaaaacccccc", 8)]
        public void Should_Return_Value(string password, int expected)
        {
            int actual = new Solution().StrongPasswordChecker(password);
            Assert.AreEqual(expected, actual, $"for {password} expected {expected} got {actual}");
        }

        [DataRow("aaaaaa", 1, 2)]
        [DataRow("aaaAAA111", 3, 3)]
        [DataRow("bbaaaaaaaaaaaaaaacccccc", 2, 7)]
        [DataRow("aaAA11", 0, 0)]
        [TestMethod]
        public void Should_Return_RepeatList(string password, int groups, int repeats)
        {
            List<int> actual = new Solution().BuildListOfRepeats(password);
            Assert.AreEqual(groups, actual.Count, $"for LENGTH {password} expected {groups} got {actual.Count}");
            var actual_repeated = actual.Sum(a => a / 3);
            Assert.AreEqual(repeats, actual_repeated, $"for REPEATS {password} expected {repeats} got {actual_repeated}");
        }
    }
}
