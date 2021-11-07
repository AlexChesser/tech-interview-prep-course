using System;

namespace  _213_HouseRobberII
{
    public class Solution
    {
        private int RangedRob(int[] nums, int start, int finish)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            int next, nextPlusOne;
            nextPlusOne = 0;
            next = nums[n - 1];

            for (int i = start; i < finish; --i)
            {
                int current = Math.Max(next, nextPlusOne + nums[i]);
                nextPlusOne = next;
                next = current;
            }
            return next;
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            int track1 = RangedRob(nums, 0, nums.Length - 2);
            int track2 = RangedRob(nums, 1, nums.Length - 1);
            return Math.Max(track1, track2);
        }
    }
}