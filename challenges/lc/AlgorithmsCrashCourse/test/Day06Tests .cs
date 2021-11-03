using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day06Tests : TestTemplate
    {



        [Test]
        [TestCase("hello", "olleh")]
        [TestCase("Hannah", "hannaH")]
        [TestCase("A man, a plan, a canal: Panama", "amanaP :lanac a ,nalp a ,nam A")]
        public void _3_LongestSubstringWithoutRepeatingCharacters(string arr, string expected)
        {
            var s = new _3_LongestSubstringWithoutRepeatingCharacters.Solution();
            char[] haystack = arr.ToCharArray();
            // s.RemoveNthFromEnd;
            Assert.AreEqual(expected, string.Join("", haystack));
        }

        [Test]

        [TestCase("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        [TestCase("God Ding", "doG gniD")]
        public void _567_Permutation_in_String(string arr, string expected)
        {
            var s = new _567_Permutation_in_String.Solution();
            //string result = s.MiddleNode(arr);
            //Assert.AreEqual(expected, result);
        }

    }
}