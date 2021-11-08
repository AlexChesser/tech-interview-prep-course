using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {
        [Test]
        [TestCase("[1,3,2,5]", "[2,1,3,null,4,null,7]", "3,4,5,5,4,0,7")]
        [TestCase("[1]", "[1,2]", "2,2")]
        public void _617_MergeTwoBinaryTrees(string arr1, string arr2, string expected)
        {
            var s = new _617_MergeTwoBinaryTrees.Solution();
            TreeNode t1 = arr1.ToIntArray().ToBinaryTree();
            TreeNode t2 = arr2.ToIntArray().ToBinaryTree();
            TreeNode result = s.MergeTrees(t1, t2);
            Assert.AreEqual(expected, result.CommaJoin());
        }


    }

}