using System;
using System.Linq;
using System.Collections.Generic;

namespace SplendorGame;

public class Splendor
{
    public Player player = new Player();
    public Queue<Card> purchases = new();

    public Splendor() { }

    public Splendor(int[] gems, List<Card> cards)
    {
        player = new()
        {
            Gems = gems,
            Cards = cards
        };
        foreach (Card c in cards)
        {
            player.Hand[c.Color]++;
        }
    }

    public bool CanPurchase(Player p, Card c)
    {
        for (int i = 0; i < p.Gems.Length; i++)
        {
            if (p.Gems[i] - (Math.Max(c.Cost[i] - p.Hand[i], 0)) < 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool Purchase(Card c)
    {
        if (!CanPurchase(player, c))
        {
            return false;
        }
        for (int i = 0; i < player.Gems.Length; i++)
        {
            player.Gems[i] -= Math.Max(c.Cost[i] - player.Hand[i], 0);
        }
        player.Cards.Add(c);
        player.Hand[c.Color]++;
        return true;
    }

    public void RequestPurchase(Card c)
    {
        purchases.Enqueue(c);
    }

    public void ExecutePurchases()
    {
        while (purchases.Count > 0)
        {
            Purchase(purchases.Dequeue());
        }
    }
}
