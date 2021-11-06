using System;

namespace _733_FloodFill
{
    public class Solution
    {
        private void ChangeNeighbors(int[][] image, int row, int col, int from, int to)
        {
            //Console.WriteLine($"setting {image.ToNestedString()} r:{row} c:{col} f:{from} t:{to}");
            if (image[row][col] == from) return;
            image[row][col] = to;
            if (row > 0) ChangeNeighbors(image, row - 1, col, from, to);
            if (col > 0) ChangeNeighbors(image, row, col - 1, from, to);
            if (row < image.Length - 1) ChangeNeighbors(image, row + 1, col, from, to);
            if (col < image[0].Length - 1) ChangeNeighbors(image, row, col + 1, from, to);
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor) return image;
            ChangeNeighbors(image, sr, sc, image[sr][sc], newColor);
            return image;
        }
    }
}