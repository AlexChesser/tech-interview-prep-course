using System;
using System.Diagnostics;

namespace _977_SquaresofaSortedArray
{
    public class Solution
    {
        public int[] SortedSquares(int[] nums)
        {
            Debug.Write("Got input array: ");
            Debug.WriteLine(string.Join(",", nums));
            int[] result = new int[nums.Length];
            int left = 0;
            int right = nums.Length - 1;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                Debug.WriteLine($"comparing LEFT: number {nums[left]} to right number {nums[right]}");
                if (Math.Abs(nums[left]) >= Math.Abs(nums[right]))
                {
                    result[i] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[i] = nums[right] * nums[right];
                    right--;
                }
                Debug.WriteLine(string.Join(",", result));
            }
            return result;
        }
    }

}