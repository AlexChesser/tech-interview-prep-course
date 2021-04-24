using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dedupe.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DedupeTests_112()
        {
            //  Input: nums = [1,1,2]
            //  Output: 2, nums = [1,2]
            int[] arr = new int[] { 1, 1 , 2 };
            int x = new Solution().RemoveDuplicates(arr);
            Assert.AreEqual(x, 2, "value must be 2");
            Assert.AreEqual(arr[0], 1, "array incorrect" );
            Assert.AreEqual(arr[1], 2, "array incorrect" );
            
        }

        [TestMethod]
        public void DedupeTests_11()
        {
            //  Input: nums = [1,1]
            //  Output: 1, nums = [1]
            int[] arr = new int[] { 1, 1 };
            int x = new Solution().RemoveDuplicates(arr);
            Assert.AreEqual(x, 1, "value must be 1");
            Assert.AreEqual(arr[0], 1, "array incorrect" );
        }

        [TestMethod]
        public void DedupeTests_null()
        {
            int[] arr = null;
            int x = new Solution().RemoveDuplicates(arr);
            Assert.AreEqual(x, 0, "value must be 0");
        }

        [TestMethod]
        public void DedupeTests_5()
        {
            //  Input: nums = [0,0,1,1,1,2,2,3,3,4]
            //  Output: 5, nums = [0,1,2,3,4]
            int[] arr = new int[] { 0,0,1,1,1,2,2,3,3,4 };
            int x = new Solution().RemoveDuplicates(arr);
            Assert.AreEqual(x, 5, "value must be 5");
            Assert.AreEqual(arr[0], 0, "array incorrect" );
            Assert.AreEqual(arr[1], 1, "array incorrect" );
            Assert.AreEqual(arr[2], 2, "array incorrect" );
            Assert.AreEqual(arr[3], 3, "array incorrect" );
            Assert.AreEqual(arr[4], 4, "array incorrect" );
            
        }
    }
}
