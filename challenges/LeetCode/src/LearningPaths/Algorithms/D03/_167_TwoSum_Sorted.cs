using System;
using System.Diagnostics;

namespace _167_TwoSum_Sorted
{
    public class Solution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int left = 0,
                right = numbers.Length - 1;
            while (left <= right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return default;
        }
    }
}