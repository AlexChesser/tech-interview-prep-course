using NUnit.Framework;
using NUnitLite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

// We’re going to initialize the game with a board and a player on it. The parameters we’ll start with are as follows:

// n: board dimension (int), so board is of dimensions (n x n)
// row: position of player in Y dimension
// col: position of player in X dimension
// orientation: direction player is facing (N, E, S, W)

// ex: 3 x 3 board with player at 0,1 and facing south

//=========================================================


// printBoard()

// Will print the following to the console for a 3 x 3 board with player at 0,1 and facing south

// - v -
// - - -
// - - -

// - is an empty space
// ^ is player facing north
// > is player facing east
// v is player facing south
// < is player facing west

//=========================================================

// start
// - v - 
// - - -
// - - -

// move(“FLFR”)

// end
// - - - 
// - - v
// - - -

// F: step forward 1 grid position in whatever direction player is facing
// L: rotation 90 degrees in place to the left (counterclockwise)
// R: rotation 90 degrees in place to the right (clockwise)

public class Runner {
    public static int Main(string[] args) {
        return new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] {"--labels=All"});
    }

    public class Direction {
        public int row { get; set; }
        public int col { get; set; }
        public int position { get; set; }
        public char icon { get; set; }
    }

    public static class Cardinal {
        public static Direction NORTH = new Direction { row = -1, col = 0, icon = '^', position = 0 };
        public static Direction EAST = new Direction { row = 0, col = 1, icon = '>', position = 1 };
        public static Direction SOUTH = new Direction { row = 1, col = 0, icon = 'v', position = 2};
        public static Direction WEST = new Direction { row = 0, col = -1, icon = '<', position = 3};
    }

    public static List<Direction> rotate = new List<Direction>{ 
        Cardinal.NORTH,
        Cardinal.EAST,
        Cardinal.SOUTH,
        Cardinal.WEST
    };

    public class Player {
        public int row { get; set; }
        public int col { get; set; }
        public Direction direction { get; set; }
    }

    public class Game {

        public Player player { get; set; }
        public List<char[]> board { get; set; }

        public Game(){}

        public Game(int n, int row, int col, Direction orientation){
            player = new Player { row = row, col = col, direction = orientation };
            board = new List<char[]>();
            for (int i = 0; i < n; i++) {
                char[] c = new char[n];
                for (int j = 0; j < n; j++)
                {
                    c[j] = '-';
                }
                board.Add(c);
            }
            board[row][col] = orientation.icon;
        }

        public string printBoard(){
            return string.Join("\n", board.Select(r => string.Join(' ', r)));
        }

        public void Move(string movements){
             foreach (char item in movements.ToCharArray()) {
                 Move(item);
             }
        }

        public void Move(char command){
            int rotation_next;
            Direction next;
            switch(command){
                case 'F':
                    board[player.row][player.col] = '-';
                    player.col += player.direction.col;
                    player.row += player.direction.row;
                    if(player.col < 0){
                        player.col = board.Count - 1;
                    }
                    if(player.row < 0){
                        player.row = board.Count - 1;
                    }
                    if(player.col >= board.Count){
                        player.col = 0;
                    }
                    if(player.row >= board.Count){
                        player.row = 0;
                    }
                    board[player.row][player.col] = player.direction.icon;
                    break;
                case 'L':
                    rotation_next = player.direction.position == 0 ? 3 : player.direction.position - 1;
                    next = rotate[rotation_next];
                    player.direction = next;
                    board[player.row][player.col] = next.icon;
                    break;
                case 'R':
                    rotation_next = player.direction.position == 3 ? 0 : player.direction.position + 1;
                    next = rotate[rotation_next];
                    player.direction = next;
                    board[player.row][player.col] = next.icon;
                    break;
                default:
                    break;
            }
        }
    }


    [TestFixture]
    public class GameTests {

        [Test]
        public void InitializeBoardTest() {
            Game g = new(3, 1, 1, Cardinal.NORTH);
            Assert.AreEqual(g.board[1][1], '^');
        }

        [Test]
        public void PrintBoardTest() {
            Game g = new(3, 1, 1, Cardinal.NORTH);
            string foo = "- - -\n- ^ -\n- - -";
            Console.WriteLine(g.printBoard());
            Assert.AreEqual(foo, g.printBoard());
        }

        [Test]
        [TestCase('L', "- - -\n- < -\n- - -")]
        [TestCase('R', "- - -\n- > -\n- - -")]
        [TestCase('F', "- ^ -\n- - -\n- - -")]
        public void MoveTest(char command, string expect) {
            Game g = new(3, 1, 1, Cardinal.NORTH);
            g.Move(command);
            Console.WriteLine(g.printBoard());
            Assert.AreEqual(expect, g.printBoard());
        }

        [Test]
        [TestCase("FR", "- > -\n- - -\n- - -")]
        [TestCase("FRF", "- - >\n- - -\n- - -")]
        [TestCase("FRFF", "> - -\n- - -\n- - -")]
        public void MoveTest(string command, string expect) {
            Game g = new(3, 1, 1, Cardinal.NORTH);
            g.Move(command);
            Console.WriteLine(g.printBoard());
            Assert.AreEqual(expect, g.printBoard());
        }
    }
}
