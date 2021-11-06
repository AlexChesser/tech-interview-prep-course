namespace _35_SearchInsertPosition
{
    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int min = 0;
            int max = nums.Length - 1;
            if (target < nums[min])
            {
                return 0;
            }
            if (target > nums[max])
            {
                return nums.Length;
            }
            while (min <= max)
            {
                int checkAt = min + (max - min) / 2;
                if (nums[checkAt] < target)
                {
                    min = checkAt + 1;
                }
                else
                {
                    max = checkAt - 1;
                }
            }
            return min;
        }
    }
}