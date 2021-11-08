using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("[[1,2],[3,4]]", 1, 4, "[[1,2,3,4]]")]
        [TestCase("[[1,2],[3,4]]", 2, 4, "[[1,2],[3,4]]")]
        public void _566_ReshapetheMatrix(string arr, int r, int c, string expected)
        {
            var s = new _566_ReshapetheMatrix.Solution();
            int[][] result = s.MatrixReshape(arr.ToMultiDimensionalArray(), r, c);
            Assert.AreEqual(expected, result.ToNestedString());
        }
    }
}