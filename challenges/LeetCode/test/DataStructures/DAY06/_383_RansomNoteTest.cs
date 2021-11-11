using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]

        [TestCase("a", "b", false)]
        [TestCase("aa", "ab", false)]
        [TestCase("aa", "aab", true)]

        public void _383_RansomNote(string arr, string mag, bool expected)
        {
            var s = new _383_RansomNote.Solution();
            bool result = s.CanConstruct(arr, mag);
            Assert.AreEqual(expected, result);
        }
    }
}