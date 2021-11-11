using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {

        [Test]
        [TestCase("[[2,1,1],[1,1,0],[0,1,1]]", 4)]
        [TestCase("[[2,1,1],[0,1,1],[1,0,1]]", -1)]
        public void _994_RottingOranges(string arr, int expected)
        {
            var s = new _994_RottingOranges.Solution();
            int result = s.OrangesRotting(arr.ToMultiDimensionalArray());
            Assert.AreEqual(expected, result);
        }
    }
}