using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DataStructuresTests : TestTemplate
    {

        [Test]
        [TestCase("[[5,3,.,.,7,.,.,.,.],[6,.,.,1,9,5,.,.,.],[.,9,8,.,.,.,.,6,.],[8,.,.,.,6,.,.,.,3],[4,.,.,8,.,3,.,.,1],[7,.,.,.,2,.,.,.,6],[.,6,.,.,.,.,2,8,.],[.,.,.,4,1,9,.,.,5],[.,.,.,.,8,.,.,7,9]]", true)]
        [TestCase("[[8,3,.,.,7,.,.,.,.],[6,.,.,1,9,5,.,.,.],[.,9,8,.,.,.,.,6,.],[8,.,.,.,6,.,.,.,3],[4,.,.,8,.,3,.,.,1],[7,.,.,.,2,.,.,.,6],[.,6,.,.,.,.,2,8,.],[.,.,.,4,1,9,.,.,5],[.,.,.,.,8,.,.,7,9]]", false)]
        [TestCase("[[.,.,.,.,5,.,.,1,.],[.,4,.,3,.,.,.,.,.],[.,.,.,.,.,3,.,.,1],[8,.,.,.,.,.,.,2,.],[.,.,2,.,7,.,.,.,.],[.,1,5,.,.,.,.,.,.],[.,.,.,.,.,2,.,.,.],[.,2,.,9,.,.,.,.,.],[.,.,4,.,.,.,.,.,.]]", false)]
        public void _36_ValidSudoku(string arr, bool expected)
        {
            var s = new _36_ValidSudoku.Solution();
            bool result = s.IsValidSudoku(arr.ToMultiDimensionalCharArray());
            Assert.AreEqual(expected, result);
        }
    }
}