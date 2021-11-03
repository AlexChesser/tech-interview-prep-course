using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day04Tests : TestTemplate
    {
        [Test]
        [TestCase("hello", "olleh")]
        [TestCase("Hannah", "hannaH")]
        public void _344_ReverseString(string arr, string expected)
        {
            var s = new _344_ReverseString.Solution();
            char[] haystack = arr.ToCharArray();
            s.ReverseString(haystack);
            Assert.AreEqual(expected, string.Join(",", haystack));
        }

        [Test]

        [TestCase("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        [TestCase("God Ding", "doG gniD")]
        public void _557_ReverseWordsinaStringIII(string arr, int target, string expected)
        {
            var s = new _557_ReverseWordsinaStringIII.Solution();
            string result = s.ReverseWords(arr);
            Assert.AreEqual(expected, result);
        }

    }
}