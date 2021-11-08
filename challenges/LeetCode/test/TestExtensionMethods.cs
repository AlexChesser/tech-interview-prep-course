using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class TestExtensionMethods
    {
        [Test]
        public void CanCreateAMultiDImensionalArray()
        {
            //[[1,1,1],[1,1,0],[1,0,1]]
            string input = "[[1,1,1],[1,1,1],[1,1,1]]";
            int[][] result = input.ToMultiDimensionalArray();
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Assert.AreEqual(result[i][j], 1);
                }
            }
        }

        [Test]
        public void WillReturnToString()
        {
            string input = "[[1,1,1],[1,1,1],[1,1,1]]";
            int[][] result = input.ToMultiDimensionalArray();
            Assert.AreEqual(result.ToNestedString(), input);
        }

        [Test]
        public void WillBuildBinaryTree()
        {
            string input = "1,2,3,4,5,6,7,8,9";
            TreeNode result = input.ToIntArray().ToBinaryTree();
            Assert.AreEqual(input, result.CommaJoin());
        }
    }
}