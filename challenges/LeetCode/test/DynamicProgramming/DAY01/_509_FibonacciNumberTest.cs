using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]


        public void _509_FibonacciNumber(int n, int expected)
        {
            var s = new _509_FibonacciNumber.Solution();
            int result = s.Fib(n);
            Assert.AreEqual(expected, result);
        }
    }
}