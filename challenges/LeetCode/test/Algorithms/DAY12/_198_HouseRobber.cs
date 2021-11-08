using System;

namespace _198_HouseRobber
{
    /*
    You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

    Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.
    */

    public class Solution
    {
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }
            int next, nextPlusOne;
            nextPlusOne = 0;
            next = nums[n - 1];

            for (int i = n - 2; i >= 0; --i)
            {
                int current = Math.Max(next, nextPlusOne + nums[i]);
                nextPlusOne = next;
                next = current;
            }
            return next;
        }
    }
}