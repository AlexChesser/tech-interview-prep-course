# Splendor

Splendor is a card-based board game where players buy cards in exchange for colored gems. In this game we care about two things, gems and cards.

Players can have any number of gems in five colors.

(Blue), (W)hite, (G)reen, (R)ed, and (Y)ellow.

Players can exchange gems for cards.

```
+---------------+
|             G |
|               |
|               |
|               |
|               |
| 3W            |
| 2G            |
| 1R            |
+---------------+
```

This indicates taht the card costs 3 (W)hite gems, 2 (G)reen, and 1 (R)ed.  The upper right hand indicates the color of the card (this will be useful later)

For this entire problem assume there is only one player.

Data model and structure of the program is up to you.

## Problems

1. We want to write a function can_purchase() such that, given a particular card and collection of gems for a player, we return true if the player can afford the card, and false if they cannot.

2. We want to write a function purchase() such that, given a particular card and collection of gems for a player, we add the card to the players hand and subtract the cost from the players gems, if they are able to afford the card. The function should return true if the player can afford the card, and false if they cannot.

3. We want to introduce a new concept: for each card in a player’s hand of a given color, we want to reduce the cost of any new purchase by 1 gem for that held card’s color. For example, if the player holds 2 (G)reen cards and 1 (R)ed, and we are considering a card that lists its cost as 4 (G)reen, 2 (R)ed, and 1 (B)lue, then the player should be able to purchase it for 2 G, 1 R, and 1 B.

4. Imagine, now, that we are running this code in parallel where there may be multiple requests from the same player to purchase cards at the same time. How would your design change to accommodate this?
