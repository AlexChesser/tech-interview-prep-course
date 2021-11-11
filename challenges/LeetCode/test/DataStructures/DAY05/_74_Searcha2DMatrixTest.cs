using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]", 3, true)]
        [TestCase("[[1,3,5,7],[10,11,16,20],[23,30,34,60]]", 13, false)]
        public void _74_Searcha2DMatrix(string arr, int target, bool expected)
        {
            var s = new _74_Searcha2DMatrix.Solution();
            bool result = s.SearchMatrix(arr.ToMultiDimensionalArray(), target);
            Assert.AreEqual(expected, result);
        }
    }
}