using System.Collections.Generic;

namespace _994_RottingOranges
{
public class Solution
    {
        public int OrangesRotting(int[][] grid)
        {
            Queue<int[]> queue = new();

            // Step 1). build the initial set of rotten oranges
            int freshOranges = 0;
            int ROWS = grid.Length, COLS = grid[0].Length;

            for (int r = 0; r < ROWS; r++)
                for (int c = 0; c < COLS; c++)
                    if (grid[r][c] == 2)
                        queue.Enqueue(new int[] { r, c });
                    else if (grid[r][c] == 1)
                        freshOranges++;

            // Mark the round / level, _i.e_ the ticker of timestamp
            queue.Enqueue(new int[] { -1, -1 });

            // Step 2). start the rotting process via BFS
            int minutesElapsed = -1;
            int[][] directions = {
                new int[] { -1, 0 },
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 0, -1 }
            };

            while (queue.Count > 0)
            {
                int[] p = queue.Dequeue();
                int row = p[0];
                int col = p[1];
                if (row == -1)
                {
                    // We finish one round of processing
                    minutesElapsed++;
                    // to avoid the endless loop
                    if (queue.Count > 0)
                        queue.Enqueue(new int[] { -1, -1 });
                }
                else
                {
                    // this is a rotten orange
                    // then it would contaminate its neighbors
                    foreach (int[] d in directions)
                    {
                        int neighborRow = row + d[0];
                        int neighborCol = col + d[1];
                        if (neighborRow >= 0 && neighborRow < ROWS &&
                            neighborCol >= 0 && neighborCol < COLS)
                        {
                            if (grid[neighborRow][neighborCol] == 1)
                            {
                                // this orange would be contaminated
                                grid[neighborRow][neighborCol] = 2;
                                freshOranges--;
                                // this orange would then contaminate other oranges
                                queue.Enqueue(new int[] { neighborRow, neighborCol });
                            }
                        }
                    }
                }
            }

            // return elapsed minutes if no fresh orange left
            return freshOranges == 0 ? minutesElapsed : -1;
        }
    }
}