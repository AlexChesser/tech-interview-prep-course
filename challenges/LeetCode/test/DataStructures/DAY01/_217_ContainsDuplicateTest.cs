using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("1,2,3,1", true)]
        [TestCase("1,2,3,4", false)]
        [TestCase("1,1,1,3,3,4,3,2,4,2", true)]
        public void _217_ContainsDuplicate(string arr, string expected)
        {
            var s = new _217_ContainsDuplicate.Solution();
            bool result = s.ContainsDuplicate(arr.Split(",").Select(c => int.Parse(c)).ToArray());
            Assert.AreEqual(expected, result);
        }
    }
}