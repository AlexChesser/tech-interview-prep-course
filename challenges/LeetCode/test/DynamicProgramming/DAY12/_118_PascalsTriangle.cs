using System;
using System.Collections.Generic;

namespace _118_PascalsTriangle
{
    public class Solution
    {
        public IList<IList<int>> Generate(int numRows)
        {
            int[][] output = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                // Console.WriteLine($"starting on row {i + 1}");
                if (output[i] == null)
                {
                    output[i] = new int[i + 1];
                }
                output[i][0] = 1;
                output[i][output[i].Length - 1] = 1;
                for (int j = 1; j < output[i].Length - 1; j++)
                {
                    int[] rowAbove = output[i - 1];
                    // Console.WriteLine($"{rowAbove.CommaJoin()} {rowAbove[j - 1]} {rowAbove[j]}  {j}");
                    output[i][j] = rowAbove[j - 1] + rowAbove[j];
                }
                // Console.WriteLine(output[i].CommaJoin());
            }
            return output;
        }
    }
}