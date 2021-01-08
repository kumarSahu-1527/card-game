using CardGame.Helpers.ExtensionMethods;
using CardGame.Models;
using CardGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Helpers
{
    /// <summary>
    /// Handles all deck behaviours
    /// </summary>
    public class DeckMaster
    {
        /// <summary>
        /// Method to create new deck
        /// </summary>
        /// <returns>New Deck</returns>
        public static Queue<Card> NewDeck()
        {
            try
            {
                Queue<Card> deck = new Queue<Card>();
                for (int i = 2; i <= 14; i++)
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        deck.Enqueue(new Card()
                        {
                            Suit = suit,
                            NumericValue = i
                        });
                    }
                }
                return deck.Shuffle();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error creating new deck...");
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
    }
}
