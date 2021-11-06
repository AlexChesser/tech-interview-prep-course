using System;
using System.Diagnostics;

namespace _189_RotateArray
{
    public class Solution
    {

        private void Reverse(int[] nums, int from, int to)
        {
            while (from < to)
            {
                int tmp = nums[from];
                nums[from++] = nums[to];
                nums[to--] = tmp;
            }
        }

        public void Rotate(int[] nums, int k)
        {
            int modk = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, modk - 1);
            Reverse(nums, modk, nums.Length - 1);
        }
    }
}