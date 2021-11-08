using System;

namespace _566_ReshapetheMatrix
{
    public class Solution
    {
        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            int[][] res = new int[r][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new int[c];
            }
            if (nums.Length == 0 || r * c != nums.Length * nums[0].Length)
                return nums;
            int rows = 0, cols = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    // TODO rewrite this one 
                    res[rows][cols] = nums[i][j];
                    cols++;
                    if (cols == c)
                    {
                        rows++;
                        cols = 0;
                    }
                }
            }
            return res;
        }

    }
}