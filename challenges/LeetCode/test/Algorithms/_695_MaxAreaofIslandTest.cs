using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class AlgorithmsTests : TestTemplate
    {

        [Test]
        [TestCase("[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]", 6)]
        [TestCase("[[0,0,0,0,0,0,0,0]]", 0)]
        [TestCase("[[1,1,0,0,0],[1,1,0,0,0],[0,0,0,1,1],[0,0,0,1,1]]", 4)]

        public void _695_MaxAreaofIsland(string arr, int expected)
        {
            var s = new _695_MaxAreaofIsland.Solution();
            int result = s.MaxAreaOfIsland(arr.ToMultiDimensionalArray());
            Assert.AreEqual(expected, result);

        }
    }
}