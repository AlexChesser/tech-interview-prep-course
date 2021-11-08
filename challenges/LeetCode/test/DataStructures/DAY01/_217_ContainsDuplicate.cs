using System.Collections.Generic;

namespace _217_ContainsDuplicate
{
    public class Solution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> dupeCheck = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dupeCheck.Contains(nums[i]))
                {
                    return true;
                }
                dupeCheck.Add(nums[i]);
            }
            return false;
        }
    }
}