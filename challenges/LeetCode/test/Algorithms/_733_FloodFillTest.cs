using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {
        [Test]
        [TestCase("[[1,1,1],[1,1,0],[1,0,1]]", 1, 1, 2, "[[2,2,2],[2,2,0],[2,0,1]]")]
        [TestCase("[[0,0,0],[0,0,0]]", 0, 0, 2, "[[2,2,2],[2,2,2]]")]
        [TestCase("[[0,0,0],[0,1,1]]", 1, 1, 1, "[[0,0,0],[0,1,1]]")]

        public void _733_FloodFill(string start, int row, int col, int color, string expected)
        {
            var s = new _733_FloodFill.Solution();
            int[][] result = s.FloodFill(start.ToMultiDimensionalArray(), row, col, color);
            Assert.AreEqual(expected, result.ToNestedString());
        }
    }
}