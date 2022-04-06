using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using SplendorGame;

public class SplendorTests
{
    [Test]
    public void NewPlayerInitializes()
    {
        Player p = new Player();
        p.Gems[Color.GREEN] = 5;
        Assert.AreEqual(p.Gems[Color.GREEN], 5);
    }

    [Test]
    public void NewGameInitializes()
    {
        List<int> gems = new() { 4, 5, 6, 7, 8 };
        List<Card> cards = new List<Card> {
            new Card {
                Color = Color.GREEN,
                Cost = new int[] { 1,2,0,0,3 }
            }
        };
        Splendor s = new Splendor(gems.ToArray(), cards);
        if (s.player != null)
        {
            Assert.AreEqual(s.player.Cards[0].Color, Color.GREEN);
        }
    }

    [Test]
    [TestCase("5,5,5,5,5", "3,3,3,0,0", true)]
    [TestCase("3,3,3,0,0", "5,5,5,5,5", false)]
    public void CanPurchaseTest(string gems, string cardCost, bool expect)
    {
        Splendor s = new Splendor();
        int[] g = gems.Split(",").Select(x => Int32.Parse(x)).ToArray();
        Card c = new Card
        {
            Color = Color.BLUE,
            Cost = cardCost.Split(",").Select(x => Int32.Parse(x)).ToArray()
        };
        Assert.AreEqual(expect, s.CanPurchase(new Player { Gems = g }, c));
    }

    [Test]
    [TestCase("5,5,5,5,5", "3,3,3,0,0", true)]
    [TestCase("3,3,3,0,0", "5,5,5,5,5", false)]
    public void MakePurchaseTest(string gems, string cardCost, bool expect)
    {
        int[] g = gems.Split(",").Select(x => Int32.Parse(x)).ToArray();
        Card c = new Card
        {
            Color = Color.BLUE,
            Cost = cardCost.Split(",").Select(x => Int32.Parse(x)).ToArray()
        };
        Splendor s = new Splendor(g, new List<Card> { c });
        Assert.AreEqual(expect, s.Purchase(c));
        Assert.AreEqual(Color.BLUE, s.player.Cards[0].Color);
    }

    [Test]
    [TestCase("5,5,4,5,5", "5,5,5,5,5", true)]
    public void MakePurchase_WithHand_Test(string gems, string cardCost, bool expect)
    {
        int[] g = gems.Split(",").Select(x => Int32.Parse(x)).ToArray();
        Card c = new Card
        {
            Color = Color.BLUE,
            Cost = cardCost.Split(",").Select(x => Int32.Parse(x)).ToArray()
        };
        Splendor s = new Splendor(g, new List<Card> { c });
        Assert.AreEqual(expect, s.CanPurchase(s.player, c));
        Assert.AreEqual(expect, s.Purchase(c));
        Assert.AreEqual(Color.BLUE, s.player.Cards[0].Color);
        Assert.AreEqual(Color.BLUE, s.player.Cards[1].Color);
    }
}