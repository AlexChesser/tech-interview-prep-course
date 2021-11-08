using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]
        [TestCase(5, "[[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]")]
        [TestCase(1, "[[1]]")]
        public void _118_PascalsTriangle(int size, string expected)
        {
            var s = new _118_PascalsTriangle.Solution();
            int[][] result = (int[][])s.Generate(size);
            Assert.AreEqual(expected, result.ToNestedString());
        }
    }
}