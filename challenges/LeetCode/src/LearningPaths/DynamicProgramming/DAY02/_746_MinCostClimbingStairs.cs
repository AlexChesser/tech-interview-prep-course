using System;

namespace  _746_MinCostClimbingStairs
{
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            int step1 = 0;
            int step2 = 0;

            for (int i = cost.Length - 1; i >= 0; i--)
            {
                int current = cost[i] + Math.Min(step1, step2);
                step1 = step2;
                step2 = current;
            }
            return Math.Min(step1, step2);
        }
    }
}