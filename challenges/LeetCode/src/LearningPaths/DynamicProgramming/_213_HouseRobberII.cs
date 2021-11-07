using System;

namespace  _213_HouseRobberII
{
    public class Solution
    {
        private int RangedRob(int[] nums, int start, int finish)
        {
            int t1 = 0;
            int t2 = 0;

            for (int i = start; i <= finish; i++)
            {
                int temp = t1;
                int current = nums[i];
                t1 = Math.Max(current + t2, t1);
                t2 = temp;
            }

            return t1;
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