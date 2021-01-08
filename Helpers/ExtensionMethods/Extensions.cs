using CardGame.Models;
using CardGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Helpers.ExtensionMethods
{
    /// <summary>
    /// Handles all extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extension method to get the description of card
        /// </summary>
        /// <param name="card">Card</param>
        /// <returns>Card Description</returns>
        public static string GetCardDescription(this Card card)
        {
            try
            {
                string cardFace = "";
                switch (card.NumericValue)
                {
                    case 11:
                        cardFace = "J";
                        break;
                    case 12:
                        cardFace = "Q";
                        break;
                    case 13:
                        cardFace = "K";
                        break;
                    case 14:
                        cardFace = "A";
                        break;
                    default:
                        cardFace = card.NumericValue.ToString();
                        break;
                }
                return cardFace + " of " + Enum.GetName(typeof(Suit), card.Suit);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return "";
            }
        }

        /// <summary>
        /// Extension method to shuffle the deck using Fisher-Yates algorithm
        /// </summary>
        /// <param name="cards">Deck</param>
        /// <returns>Shuffled Deck</returns>
        public static Queue<Card> Shuffle(this Queue<Card> deck)
        {
            try
            {
                if (deck != null && deck.Count > 1)
                {
                    List<Card> cards = deck.ToList();
                    Random r = new Random(DateTime.Now.Millisecond);
                    for (int n = cards.Count - 1; n > 0; --n)
                    {
                        int k = r.Next(n + 1);
                        Card temp = cards[n];
                        cards[n] = cards[k];
                        cards[k] = temp;
                    }

                    Queue<Card> shuffledDeck = new Queue<Card>();
                    foreach (var card in cards)
                    {
                        shuffledDeck.Enqueue(card);
                    }

                    return shuffledDeck;
                }
                return deck;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error shuffling the deck...");
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }
}
