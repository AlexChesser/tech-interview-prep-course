using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace buylowsellhigh.tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        [DataRow(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [DataRow(new int[] { 7, 6, 5, 4, 3, 2, 1 }, 0)]
        public void GetMaxProfit(int[] arr, int expected){
            int actual = new Solution().MaxProfit(arr);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxProfit_runtest(){
            Assert.IsTrue(true);
        }

    }
}
