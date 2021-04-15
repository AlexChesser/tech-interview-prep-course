using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class StringToIntTests
    {
        [TestMethod]
        [DataRow("42", 42)]
        [DataRow("   -42", -42)]
        [DataRow("4193 with words", 4193)]
        [DataRow("words and 987", 0)]
        [DataRow("-91283472332", -2147483648)]
        public void Should_return_expected_value(string input, int expected)
        {
            int actual = new Solution().MyAtoi(input);
            Assert.AreEqual(expected, actual, $"TESTED: '{input}' expected: {expected} actual: {actual}");
        }
    }
}
