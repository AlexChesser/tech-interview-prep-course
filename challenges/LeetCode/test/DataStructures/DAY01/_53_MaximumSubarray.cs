using System;

namespace _53_MaximumSubarray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum < 0)
                {
                    sum = 0;
                }
                sum += nums[i];
                if (sum > max)
                {
                    max = sum;
                }
            }
            return max;
        }
    }
}