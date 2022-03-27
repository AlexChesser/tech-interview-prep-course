using System;
using NUnit.Framework;

namespace TH01.AllDigitsUnique;

public class Solution
{
    // approximate time to all tests passing including project set up ~30 minutes.
    // scaling: O(N) this function will run at most 10 times no matter how large N is (assuming uint32)
    // memory: O(1)
    public bool AllDigitsUnique(uint value)
    {
        int[] found = new int[10];
        while (value > 0)
        {
            // note that a MOD 10 operation on a max uint returns a -1 if it is cast to an int on this line
            // safer for the edge case if we cast to an int when we attempt to access the array
            uint remainder = value % 10;
            if (found[(int)remainder] > 0)
            {
                return false;
            }
            found[(int)remainder]++;
            value /= 10;
        }
        return true;
    }

    [Test]
    // 0 to 4,294,967,295
    [TestCase((uint)0, true)]
    [TestCase((uint)777777, false)]
    [TestCase((uint)48778584, false)]
    [TestCase((uint)17308459, true)]
    [TestCase((uint)1234567890, true)]
    [TestCase((uint)4294967295, false)]
    public void TestMethod1(uint checkNum, bool expect)
    {
        Assert.AreEqual(expect, AllDigitsUnique(checkNum));
    }
}