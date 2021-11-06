using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    partial class DynamicProgrammingTests : TestTemplate
    {

        [Test]
        [TestCase("[7,1,5,3,6,4]", 5)]
        [TestCase("[7,6,5,4,3,1]", 0)]
        public void _121_BestTimetoBuyandSellStock(string arr, int expected)
        {
            var s = new _121_BestTimetoBuyandSellStock.Solution();
            int result = s.MaxProfit(arr.ToIntArray());
            Assert.AreEqual(expected, result);
        }
    }
}