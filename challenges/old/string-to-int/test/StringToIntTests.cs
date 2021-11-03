using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class StringToIntTests
    {
        [TestMethod]
        [DataRow("42", 42)]
        [DataRow("", 0)]
        [DataRow("-42", -42)]
        [DataRow("+-12", 0)]
        [DataRow("--12", 0)]
        [DataRow("-+12", 0)]
        [DataRow("000000000000000000000000000000000012", 12)]
        [DataRow("00000000000000000000000000000000", 0)]
        [DataRow("0000000000000000000000000000000000129999999999999999999999999999999999999999", int.MaxValue)]
        [DataRow("-0000000000000000000000000000000000129999999999999999999999999999999999999999", int.MinValue)]
        [DataRow("   -42", -42)]
        [DataRow("4193 with words", 4193)]
        [DataRow("+", 0)]
        [DataRow("-", 0)]
        [DataRow("    +", 0)]
        [DataRow("    -", 0)]
        [DataRow("words and 987", 0)]
        [DataRow("-91283472332", int.MinValue)]
        [DataRow("-9128347233", int.MinValue)] // 10 digit negative number that is out of bounds
        [DataRow("00000-42a1234", 0)]
        [DataRow("00000+42a1234", 0)]
        
        public void Should_return_expected_value(string input, int expected)
        {
            System.Console.WriteLine($"Beginning Test: `{input}` {expected}");
            int actual = new Solution().MyAtoi(input);
            Assert.AreEqual(expected, actual, $"TESTED: '{input}' expected: {expected} actual: {actual}");
        }
    }
}
