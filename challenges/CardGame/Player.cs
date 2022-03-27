using System.Collections.Generic;
namespace SplendorGame;
public class Player
{
    public int[] Gems { get; set; }
    public List<Card> Cards { get; set; }
    public Dictionary<int, int> Hand { get; set; }
    public Player()
    {
        Gems = new int[5];
        Cards = new();
        Hand = new()
        {
            { Color.RED, 0 },
            { Color.GREEN, 0 },
            { Color.BLUE, 0 },
            { Color.YELLOW, 0 },
            { Color.WHITE, 0 },
        };
    }
}