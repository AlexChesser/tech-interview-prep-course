using System;

namespace _542_01Matrix
{
    public class Solution
    {

        //         Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
        // Output: [[0,0,0],[0,1,0],[0,0,0]]

        // Example 2:

        // Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
        // Output: [[0,0,0],[0,1,0],[1,2,1]]


        public int[][] UpdateMatrix(int[][] mat)
        {
            int[][] output = new int[mat.Length][];
            int worstCase = mat.Length - 1 + mat[0].Length - 1;
            for (int i = 0; i < mat.Length; i++)
            {
                output[i] = new int[mat[0].Length];
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] != 0)
                    {
                        output[i][j] = worstCase;
                        if (i > 0) output[i][j] = Math.Min(output[i][j], output[i - 1][j] + 1);
                        if (j > 0) output[i][j] = Math.Min(output[i][j], output[i][j - 1] + 1);
                    }
                }
            }
            for (int i = mat.Length - 1; i >= 0; i--)
            {
                for (int j = mat[0].Length - 1; j >= 0; j--)
                {
                    if (mat[i][j] != 0)
                    {
                        if (i < mat.Length - 1) output[i][j] = Math.Min(output[i][j], output[i + 1][j] + 1);
                        if (j < mat[0].Length - 1) output[i][j] = Math.Min(output[i][j], output[i][j + 1] + 1);

                    }
                }
            }
            return output;
        }
    }
}