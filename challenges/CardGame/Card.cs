using System.Collections.Generic;
namespace SplendorGame;
public class Card
{
    public int Color { get; set; }
    public int[] Cost { get; set; }
    public Card()
    {
        Cost = new int[5];
    }
}