using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("anagram", "nagaram", true)]
        [TestCase("rat", "car", false)]

        public void _242_ValidAnagram(string arr, string arr2, bool expected)
        {
            var s = new _242_ValidAnagram.Solution();
            bool result = s.IsAnagram(arr, arr2);
            Assert.AreEqual(expected, result);
        }
    }
}