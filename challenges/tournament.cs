using NUnit.Framework;
using NUnitLite;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Runner {
    public static int Main(string[] args) {
        return new AutoRun(Assembly.GetCallingAssembly()).Execute(new String[] {"--labels=All"});
    }

    public class Player {
        public int id { get; set; }
        public string name { get; set; }
        public int power { get; set; }
    }

    public class TournamentEntry {
        public Player player { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }

    public interface IDecisionRule {
        int Compete(Player p1, Player p2);
    }

    public class PowerCompetitionRule : IDecisionRule {
        public int Compete(Player p1, Player p2){
            if(p1.power > p2.power){
                return p1.id;
            } else if(p1.power < p2.power){
                return p2.id;
            } else {
                return Math.Max(p1.id, p2.id);
            }
        }
    }

    public class RandoPowerCompetitionRule : IDecisionRule {
        public int Compete(Player p1, Player p2){
            int powersum = p1.power + p2.power;
            double chance = (double)p1.power / powersum;
            Random rnd = new Random();
            double roll = rnd.NextDouble();
            Console.WriteLine($"chance: {chance} roll {roll}");
            if(roll < chance){
                return p2.id;
            }
            return p1.id;
        }
    }

    public class NameCompetitionRule : IDecisionRule {
        public int Compete(Player p1, Player p2){
            if(p1.name.Length > p2.name.Length){
                return p1.id;
            } else if(p1.name.Length < p2.name.Length){
                return p2.id;
            } else {
                return Math.Max(p1.id, p2.id);
            }
        }        
    }

    public class Solution {

        public List<TournamentEntry> RunTournament(List<Player> players, IDecisionRule rules){
            List<TournamentEntry> tes = new List<TournamentEntry>();
            foreach(var p in players){
                tes.Add(new TournamentEntry{ player = p, Wins = 0, Losses = 0 });
            }
            for(int left = 0; left < tes.Count; left++){
                TournamentEntry te1 = tes[left];
                for(int right = left + 1; right < tes.Count; right++){
                    TournamentEntry te2 = tes[right];
                    int winner = rules.Compete(te1.player, te2.player);
                    if(te1.player.id == winner){
                        te1.Wins++;
                        te2.Losses++;
                    } else {
                        te1.Losses++;
                        te2.Wins++;
                    }
                }
            }
            return tes.OrderByDescending(t => t.Wins).ToList();
        }
    }

    #region SquareTests

    [Test]
    public void TestDatashape(){
        List<Player> players = new List<Player>{
            new Player { id = 0, name = "Rafa0", power = 1 },
            new Player { id = 1, name = "Rafa1", power = 2 },
            new Player { id = 2, name = "Rafa2", power = 3 },
            new Player { id = 3, name = "Rafa3", power = 3 },
            new Player { id = 4, name = "Rafa4", power = 5 },
        };
        Solution s = new Solution();
        var result = s.RunTournament(players, new PowerCompetitionRule());
        foreach(TournamentEntry t in result){
            Console.WriteLine($"{t.player.name} w: {t.Wins} l: {t.Losses} ");
        }
    }

    [Test]
    public void TestDataNameRule(){
        List<Player> players = new List<Player>{
            new Player { id = 0, name = "R", power = 5 },
            new Player { id = 1, name = "Ra", power = 5 },
            new Player { id = 2, name = "Raf", power = 5 },
            new Player { id = 3, name = "Raz", power = 5 },
            new Player { id = 4, name = "Rafa", power = 5 },
        };
        Solution s = new Solution();
        var result = s.RunTournament(players, new NameCompetitionRule());
        foreach(TournamentEntry t in result){
            Console.WriteLine($"{t.player.name} w: {t.Wins} l: {t.Losses} ");
        }
    }


    [Test]
    public void TestDataPowerRandoRule(){
        List<Player> players = new List<Player>{
            new Player { id = 0, name = "R", power = 50 },
            new Player { id = 1, name = "Ra", power = 4 },
            new Player { id = 2, name = "Raf", power = 3 },
            new Player { id = 3, name = "Raz", power = 3 },
            new Player { id = 4, name = "Rafa", power = 0 },
        };
        Solution s = new Solution();
        var result = s.RunTournament(players, new RandoPowerCompetitionRule());
        foreach(TournamentEntry t in result){
            Console.WriteLine($"{t.player.name} id: {t.player.id} w: {t.Wins} l: {t.Losses} ");
        }
    }

    #endregion

    // In preparation for not knowing what question is going to be asked these 
    // "helpers" are just simple common code patterns I find I use while doing 
    // leetcode type things.
    // Adding them proactively will allow me to move faster while in the
    // heat of solving the issue.
    #region TestingHelpers


    [Test]
    [TestCase("1,2,3,4,5,6",1)]
    public void TestCreateIntArray(string input, int expect){
        int[] items = input.Split(",").Select(x => Int32.Parse(x)).ToArray();
        Assert.AreEqual(expect, items[0], "yikes these are NOT the same");
    }

    [Test]
    [TestCase("1,2,3,4,5,6",1)]
    [TestCase("[1,2,3,4,5,6]",1)]
    public void TestToIntArray(string input, int expect){
        int[] items = input.ToIntArray();
        Assert.AreEqual(expect, items[0], "yikes these are NOT the same");
    }

    [Test]
    [TestCase("1|1,2|2,3|3,4|4,5|5,6|6", "1")]
    public void TestCreateDictionary(string input, string expect){
        string[] items = input.Split(",");
        Dictionary<string, string> elements = new();
        foreach (string item in items)
        {
            string[] pair = item.Split('|');
            elements.Add(pair[0], pair[1]);
        }
        Assert.AreEqual(expect, elements["1"], "yikes these are NOT the same");
    }
    #endregion Helpers
}


// These are some additional leetcode extensions I like to
// use when working with various data structures - if you're
// asking any sort of multi dimensional array type things 
// this will help speed things up for me.
#region Extensions

public static class LeetcodeExtensions {
    public static int[] ToIntArray(this string str)
    {
        if (str.Length == 0)
        {
            return new int[] { };
        }
        return str.Replace("[", "")
            .Replace("]", "")
            .Split(",")
            .Select(c =>
            {
                if (!int.TryParse(c, out int result))
                {
                    return 0;
                };
                return result;
            })
            .ToArray();
    }

    public static int[][] ToMultiDimensionalArray(this string str)
    {
        Regex rxp = new Regex("\\[([0-9,]+?)\\]", RegexOptions.Compiled);
        List<int[]> n = new List<int[]>();
        foreach (Match match in rxp.Matches(str))
        {
            n.Add(match.Groups[1].ToString().ToIntArray());
        }
        return n.ToArray();
    }

    public static char[][] ToMultiDimensionalCharArray(this string str)
    {
        Regex rxp = new Regex("\\[([0-9\\.,]+?)\\]", RegexOptions.Compiled);
        List<char[]> n = new List<char[]>();
        foreach (Match match in rxp.Matches(str))
        {
            n.Add(match.Groups[1].ToString().Replace(",", "").ToCharArray());
        }
        return n.ToArray();
    }

    public static string ToNestedString(this int[][] arr)
    {
        return $"[{string.Join(",", arr.Select(inner => $"[{inner.CommaJoin()}]"))}]";
    }

    public static string CommaJoin(this int[] arr)
    {
        return string.Join(",", arr);
    }

    public static string CommaJoin(this char[] arr)
    {
        return string.Join(",", arr);
    }

}

#endregion

/*
Let’s work together and write a simulator for a round robin tournament. In the round robin tournament format, a group of N players compete against each other in the following manner:

1. Each player competes in a match against every other player exactly once.
2. The player with the best win-loss record is typically considered to be the winner of the round robin tournament.

Part 1

Given a list of N players, define a function that simulates a round robin tournament with those players by returning the players along with their win-loss records after all matches have been played.
These win-loss results can be returned in any order (no need to indicate who the winner of the overall tournament is), as long as it is clear how many wins and losses each player ended up with.
When two players compete in a match, the player with the higher “power” value should be the winner. 

Sample input:

[
  { 'id': 3, 'name': 'Rafa', 'power': 3 },
  { 'id': 1, 'name': 'Andy', 'power': 3 },
  { 'id': 0, 'name': 'Stef', 'power': 2 },
  { 'id': 2, 'name': 'Domi', 'power': 4 },
]

Sample output:

[
  { 'player': { 'id': 3, 'name': 'Rafa', 'power': 3 }, 'wins': 2, 'losses': 1 },
  { 'player': { 'id': 1, 'name': 'Andy', 'power': 3 }, 'wins': 1, 'losses': 2 },
  { 'player': { 'id': 0, 'name': 'Stef', 'power': 2 }, 'wins': 0, 'losses': 3 },
  { 'player': { 'id': 2, 'name': 'Domi', 'power': 4 }, 'wins': 3, 'losses': 0 },
]

Part 2

Let's make the output of our round robin tournament simulator nicer by ranking the players in the output. Let's update the function you wrote for part 1 to return the results in descending order by number of wins (i.e. the player with the most wins should be first, the player with the least wins should be last).

Sample ranked output:

[
  { 'player': { 'id': 2, 'name': 'Domi', 'power': 4 }, 'wins': 3, 'losses': 0 },
  { 'player': { 'id': 3, 'name': 'Rafa', 'power': 3 }, 'wins': 2, 'losses': 1 },
  { 'player': { 'id': 1, 'name': 'Andy', 'power': 3 }, 'wins': 1, 'losses': 2 },
  { 'player': { 'id': 0, 'name': 'Stef', 'power': 2 }, 'wins': 0, 'losses': 3 },
]



Part 3

Let's say we want to change how we determine the winner of each match in our tournament simulator. Instead of comparing the players' power and then using player id to break ties in power, let us instead compare the length of their names - the player with the longer name should win the match. If two players have names of the same length, then we use player id to break ties like before (higher id determines the winner).

We'll add one more constraint to this problem - let's refactor your code from parts 1-2 in such a way that we can choose which "winning strategy"
to use when executing the function that simulates the tournament.

Sample input:

[
  { 'id': 2, 'name': 'Dominic', 'power': 3 },
  { 'id': 3, 'name': 'Rafael', 'power': 3 },
  { 'id': 1, 'name': 'Andrey', 'power': 3 },
  { 'id': 0, 'name': 'Stef', 'power': 4 },
]

Sample ranked output w/ the new "name length strategy":

[
  { 'player': { 'id': 2, 'name': 'Dominic', 'power': 3 }, 'wins': 3, 'losses': 0 },
  { 'player': { 'id': 3, 'name': 'Rafael', 'power': 3 }, 'wins': 2, 'losses': 1 },
  { 'player': { 'id': 1, 'name': 'Andrey', 'power': 3 }, 'wins': 1, 'losses': 2 },
  { 'player': { 'id': 0, 'name': 'Stef', 'power': 4 }, 'wins': 0, 'losses': 3 },
]


Part 4

Let's make this round robin tournament simulator more exciting by introducing a winning strategy that includes an element of luck/chance.

This new strategy should work as follows: each player should have a random chance of winning a match that is relative to their power and their opponent's power. A player's chance of victory should be computed using the following formula:

(player’s power) / (player’s power + opponent’s power)

Therefore, if player A has power = 4, and player B has power = 6, then player A should have a 4/(4 + 6) = 40% chance of winning that match.

Usage of the "random winner" strategy means that this now a possible round robin tournament result:

[
  { 'player': { 'id': 3, 'name': 'Rafael', 'power': 3 }, 'wins': 2, 'losses': 1 },
  { 'player': { 'id': 2, 'name': 'Dominic', 'power': 3 }, 'wins': 2, 'losses': 1 },
  { 'player': { 'id': 1, 'name': 'Andrey', 'power': 3 }, 'wins': 2, 'losses': 1 },
  { 'player': { 'id': 0, 'name': 'Stef', 'power': 2 }, 'wins': 0, 'losses': 3 },
]

*/