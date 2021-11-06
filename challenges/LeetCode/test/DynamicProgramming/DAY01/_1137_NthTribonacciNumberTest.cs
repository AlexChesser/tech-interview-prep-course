using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]

        [TestCase(4, 4)]
        [TestCase(25, 1389537)]


        public void _1137_NthTribonacciNumber(int arr, int expected)
        {
            var s = new _1137_NthTribonacciNumber.Solution();
            int result = s.Tribonacci(arr);
            Assert.AreEqual(expected, result);
        }
    }
}