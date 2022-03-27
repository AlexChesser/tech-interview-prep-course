using System;
using System.Collections.Generic;

namespace _36_ValidSudoku
{
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {

            // foreach (var b in board)
            // {
            //     Console.WriteLine(string.Join(",", b));
            // }

            var adjustment = new List<int[]>{
                new int[]{ -1, -1 },
                new int[]{ -1, 0 },
                new int[]{ -1, 1 },
                new int[]{ 0, -1 },
                new int[]{ 0, 0 },
                new int[]{ 0, 1 },
                new int[]{ 1, -1 },
                new int[]{ 1, 0 },
                new int[]{ 1, 1 },
            };
            int[] checkSetAcross;
            int[] checkSetDown;
            int[] checkSetBox;
            for (int i = 0; i < 9; i++)
            {
                // reset all checks
                checkSetAcross = new int[9];
                checkSetDown = new int[9];
                checkSetBox = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    char valueAcross = board[i][j];
                    if (valueAcross != '.')
                    {
                        if (++checkSetAcross[valueAcross - '1'] > 1)
                        {
                            Console.WriteLine($"failing across at {i},{j}");
                            return false;
                        }
                    }
                    char valueDown = board[j][i];
                    if (valueDown != '.')
                    {
                        if (++checkSetDown[valueDown - '1'] > 1)
                        {
                            Console.WriteLine($"failing down at {i},{j}");
                            return false;
                        }
                    }

                    var centerCoords = new List<int[]>(){
                        new int[] {1,1},
                        new int[] {1,4},
                        new int[] {1,7},
                        new int[] {4,1},
                        new int[] {4,4},
                        new int[] {4,7},
                        new int[] {7,1},
                        new int[] {7,4},
                        new int[] {7,7},
                    };

                    int centerAcross = centerCoords[i][0];
                    int centerDown = centerCoords[i][1];
                    int[] coords = adjustment[j];
                    int verifyAcross = centerAcross + coords[0];
                    int verifyDown = centerDown + coords[1];
                    char valueBox = board[verifyAcross][verifyDown];
                    // Console.WriteLine($"iteration: {i},{j} checking cell {centerAcross + coords[0]} {centerAcross + coords[1]} with value {valueBox}  {centerAcross}+{coords[0]}={verifyAcross} {centerDown}+{coords[1]}={verifyDown}  ");


                    if (valueBox != '.')
                    {
                        if (++checkSetBox[valueBox - '1'] > 1)
                        {
                            // Console.WriteLine($"failing at {i},{j}");
                            // Console.WriteLine($"failing at BOX {centerAcross} {centerDown} with {valueBox} using {coords.CommaJoin()}");
                            // Console.WriteLine($"center value = {board[centerAcross][centerDown]}");
                            // Console.WriteLine($"check value = {board[centerAcross + coords[0]][centerDown + coords[1]]}");
                            // foreach (var b in board)
                            // {
                            //     Console.WriteLine(string.Join(",", b));
                            // }
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}