using System;
using System.Collections.Generic;

namespace _695_MaxAreaofIsland
{
    public class Solution
    {
        HashSet<string> visited;
        public int MaxAreaOfIsland(int[][] grid)
        {
            visited = new HashSet<string>();
            int max = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (!visited.Contains($"{i},{j}"))
                    {
                        max = Math.Max(max, GetIslandSize(grid, i, j));
                    }
                }
            }
            return max;
        }

        private int GetIslandSize(int[][] grid, int i, int j)
        {
            if (visited.Contains($"{i},{j}")) { return 0; }
            if (grid[i][j] == 0) { return 0; }
            visited.Add($"{i},{j}");
            int size = 1;
            size += i > 0 ? GetIslandSize(grid, i - 1, j) : 0;
            size += j > 0 ? GetIslandSize(grid, i, j - 1) : 0;
            size += i < grid.Length - 1 ? GetIslandSize(grid, i + 1, j) : 0;
            size += j < grid[0].Length - 1 ? GetIslandSize(grid, i, j + 1) : 0;
            return size;
        }
    }
}