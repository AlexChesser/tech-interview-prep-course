namespace _704_BinarySearch
{

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            int NOT_FOUND = -1;
            int lowPointer = 0;
            int highPointer = nums.Length;
            // start in the middle of the array
            int checkAt = nums.Length / 2;
            while (checkAt > -1 && checkAt < nums.Length)
            {
                // check at the current index
                if (nums[checkAt] == target)
                {
                    // return index if we have found it.
                    return checkAt;
                }
                int previous = checkAt;
                if (lowPointer == highPointer)
                {
                    return NOT_FOUND;
                }
                if (nums[checkAt] < target)
                {
                    lowPointer = checkAt;
                }
                if (nums[checkAt] > target)
                {
                    highPointer = checkAt;
                }
                checkAt = lowPointer + (highPointer - lowPointer) / 2;
                if (previous == checkAt)
                {
                    return NOT_FOUND;
                }
            }
            // return not found if we run out of places to look in the array
            return NOT_FOUND;
        }
    }

}