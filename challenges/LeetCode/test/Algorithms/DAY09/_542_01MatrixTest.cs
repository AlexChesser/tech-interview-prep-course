using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {

        // Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
        // The distance between two adjacent cells is 1.
        // Example 1:
        // Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
        // Output: [[0,0,0],[0,1,0],[0,0,0]]
        // Example 2:
        // Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
        // Output: [[0,0,0],[0,1,0],[1,2,1]]


        [Test]
        [TestCase("[[0,0,0],[0,1,0],[0,0,0]]", "[[0,0,0],[0,1,0],[0,0,0]]")]
        [TestCase("[[0,0,0],[0,1,0],[1,1,1]]", "[[0,0,0],[0,1,0],[1,2,1]]")]
        [TestCase("[[0],[1]]", "[[0],[1]]")]

        public void _542_01Matrix(string arr, string expected)
        {
            var s = new _542_01Matrix.Solution();
            int[][] result = s.UpdateMatrix(arr.ToMultiDimensionalArray());
            Assert.AreEqual(expected, result.ToNestedString());
        }
    }
}