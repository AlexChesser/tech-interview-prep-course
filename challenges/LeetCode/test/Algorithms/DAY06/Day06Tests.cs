using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day06Tests : TestTemplate
    {

        [Test]
        [TestCase("abcabcbb", 3)]

        public void _3_LongestSubstringWithoutRepeatingCharacters(string arr, int expected)
        {
            var s = new _3_LongestSubstringWithoutRepeatingCharacters.Solution();
            int result = s.LengthOfLongestSubstring(arr);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("ab", "eidbaooo", true)]

        public void _567_Permutation_in_String(string s1, string s2, bool expected)
        {
            var s = new _567_Permutation_in_String.Solution();
            bool result = s.CheckInclusion(s1, s2);
            Assert.AreEqual(expected, result);
        }

    }
}