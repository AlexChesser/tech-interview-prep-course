using System.Collections.Generic;

namespace _350_IntersectionofTwoArraysII
{
    public class Solution
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            List<int> output = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (!pairs.ContainsKey(nums1[i]))
                {
                    pairs.Add(nums1[i], 0);
                }
                pairs[nums1[i]]++;
            }
            for (int j = 0; j < nums2.Length; j++)
            {
                if (pairs.ContainsKey(nums2[j]) && pairs[nums2[j]] > 0)
                {
                    pairs[nums2[j]]--;
                    output.Add(nums2[j]);
                }
            }
            return output.ToArray();
        }
    }
}