using System;

namespace _88_MergeSortedArray
{
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            m--; n--;
            int right = nums1.Length - 1;
            while (m >= 0 && n >= 0)
            {
                if (nums1[m] > nums2[n])
                {
                    nums1[right--] = nums1[m--];
                }
                else
                {
                    nums1[right--] = nums2[n--];
                }
            }
            while (n >= 0)
            {
                nums1[right--] = nums2[n--];
            }
        }
    }
}