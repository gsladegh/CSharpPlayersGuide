/*
 *  Boss Battle The Card 100 XP
 *  
    The digital Realms of C# have playing cards like ours but with some differences. Each card has a color 
    (red, green, blue, yellow) and a rank (the numbers 1 through 10, followed by the symbols $, %, ^, and &). 
    The third pedestal requires that you create a class to represent a card of this nature.
    
    Objectives:
    • Define enumerations for card colors and card ranks.
    • Define a Card class to represent a card with a color and a rank, as described above.
    • Add properties or methods that tell you if a card is a number or symbol card (the equivalent of a 
    face card).
    • Create a main method that will create a card instance for the whole deck (every color with every 
    rank) and display each (for example, “The Red Ampersand” and “The Blue Seven”).
    • Answer this question: Why do you think we used a color enumeration here but made a color class 
    in the previous challenge?
 */

CardColor[] colors = new CardColor[] { CardColor.Red, CardColor.Green, CardColor.Blue, CardColor.Yellow };
CardRank[] ranks = new CardRank[] { CardRank.One, CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, 
    CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.DollarSign, CardRank.Percent, CardRank.Carot, 
    CardRank.Ampersand };

GetAllCards();

void GetAllCards()
{    
    foreach (var color in colors)
    {
        foreach (var rank in ranks)
        {          
            Card card = new Card(color, rank);
            Console.WriteLine($"The {card.Color} {card.Rank}");
        }
    }
}

class Card
{
    public CardColor Color { get; set; }
    public CardRank Rank { get; set; }

    public Card(CardColor color, CardRank rank)
    {
        Color = color;
        Rank = rank;            
    }

    bool isFaceCard => Rank == CardRank.DollarSign || Rank == CardRank.Percent || Rank == CardRank.Carot || Rank == CardRank.Ampersand;
    bool isNumberCard => !isFaceCard;
 }

public enum CardColor { Red, Green, Blue, Yellow };
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Carot, Ampersand };
