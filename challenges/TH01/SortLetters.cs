
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TH01.SortLetters;

public class Solution
{
    // approximate time to complete given test case 13 minutes
    // scaling speed and memory are both: O(n+m)
    public string SortLetters(string inputStr, string sortOrder)
    {
        Dictionary<char, int> map = new();
        string[] output = new string[sortOrder.Length];
        for (int i = 0; i < sortOrder.Length; i++)
        {
            map.Add(sortOrder[i], i);
        }
        for (int i = 0; i < inputStr.Length; i++)
        {
            output[map[inputStr[i]]] += inputStr[i];
        }
        return String.Join("", output);
    }
}

public class SortLettersTest
{
    [Test]
    [TestCase("sort the letters in this string", " isetlgornh", "     iiisssseeettttttlgorrrnnhh")]
    public void TestMethod1(string input, string order, string expect)
    {
        Assert.AreEqual(expect, new Solution().SortLetters(input, order));
    }
}