/*

Snake Game
-------------

Board is a rectangular region made of tiles where each tile has a size of 1x1. Snake is made of segments each with a size equal to a tile on the board.

Input

A board: As an array of strings or as a two-dimensional character array.
Each character represents a tile can be a free tile or an obstacle.
A free tile is represented by '.' while an obstacle is represented by '#'

A snake: As an array of zero-based row and column coordinates that represent the positions of the snake's segments on the board.
These coordinates are ordered from head to tail.


Step 1
---------------------------------
Print the board and snake.
- Use '*' to represent the snake's segments.

Input:  

Board as an array of String

board = { "........#...",
          "..#..#.#....",
          "............",
          "............",
          "............",
          "............" }

Alternatively board can be provided as an array of arrays of Char:

board = { { '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.'},
          { '.', '.', '#', '.', '.', '#', '.', '#', '.', '.', '.', '.'},
          { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
          { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
          { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
          { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.', '.'} }

snake = { {3, 2}, {3, 3}, {3, 4} }

Output:

........#...
..#..#.#....
............
..***.......
............
............


Step 2:
---------------------------------
When printing the snake's head use one of these characters depending on the direction of the snake.

<, >, ^, v

Input: Continued from step 1 with the same input.


Output:

........#...
..#..#.#....
...^........
...**.......
............
............

Step 3:
---------------------------------
Move the snake a number of steps printing the board and the snake at each step. The snake should move forward until it hits obstacles or a wall at which point:
- It should try to turn in clockwise direction ( up -> right -> down - left -> up ) if that is blocked try to turn counter-clockwise.
- If all three directions other than the opposite direction are blocked print the last snake and the phrase "Dead snake!"



*/
// To execute C#, please define "static void Main" on a class
// named Solution.

using System;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
//using Newtonsoft.Json;

class Solution
{
    // static int Main(string[] args)
    // {
    //     return new AutoRun(Assembly.GetCallingAssembly())
    //         .Execute(new String[] { "--labels=All" });
    // }

    public class SnakeGame
    {

        enum Direction { NORTH, SOUTH, EAST, WEST }

        Dictionary<string, Char> directionMap = new Dictionary<string, Char> {
            { "-1,0", '^' },
            { "1,0",  'v' },
            { "0,1",  '>' },
            { "0,-1", '<' }
        };

        public Char GetDirection(List<int[]> snake)
        {
            return directionMap[string.Join(",", $"{snake[0][0] - snake[1][0]},{snake[0][1] - snake[1][1]}")];
        }

        public string PrintBoard(Char[][] board, List<int[]> snake)
        {

            for (int i = 0; i < snake.Count; i++)
            {
                int[] pair = snake[i];
                Char mark = '*';
                if (i == 0)
                {
                    mark = GetDirection(snake);
                }
                board[pair[0]][pair[1]] = mark;
            }
            return BoardToString(board);
        }

        public string BoardToString(Char[][] board)
        {
            return $"{String.Join(Environment.NewLine, board.Select(row => String.Join("", row)).ToArray())}";
        }


        public Char[][] StringToBoard(string board)
        {
            string[] input_strings = board.Split("|");
            List<Char[]> board_builder = new();
            foreach (string s in input_strings)
            {
                board_builder.Add(s.ToCharArray());
            }
            return board_builder.ToArray();
        }
    }

    [Test]
    [TestCase("........#...|..#..#.#....|............|............|............|............", "{ {3, 2}, {3, 3}, {3, 4} }",
@"........#...
..#..#.#....
............
..<**.......
............
............")]
    public void TestTest_2(string input, string snake, string expect)
    {
        SnakeGame sg = new SnakeGame();
        string[] input_strings = input.Split("|");
        List<Char[]> board_builder = new();
        foreach (string s in input_strings)
        {
            board_builder.Add(s.ToCharArray());
        }
        List<int[]> snake_array = new List<int[]>{
               new int[] {3, 2},
               new int[] {3, 3},
               new int[] {3, 4}
            };
        Assert.AreEqual(sg.PrintBoard(board_builder.ToArray(), snake_array), expect);
    }

    [Test]
    [TestCase("3,2|3,3|3,4", '<')]
    [TestCase("4,3|3,3|3,4", 'v')]
    [TestCase("2,3|3,3|3,4", '^')]
    [TestCase("3,4|3,3|3,2", '>')]
    public void GetDirectionTest(string snake, char expect)
    {
        SnakeGame sg = new SnakeGame();

        List<int[]> snakeArray = new();
        foreach (string segment in snake.Split("|"))
        {
            string[] xy = segment.Split(",");
            snakeArray.Add(new int[] { Int32.Parse(xy[0]), Int32.Parse(xy[1]) });
        }
        Assert.AreEqual(sg.GetDirection(snakeArray), expect);
    }
}

