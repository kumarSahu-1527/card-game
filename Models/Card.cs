using CardGame.Helpers.ExtensionMethods;
using CardGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Models
{
    /// <summary>
    /// Handles all card behaviours
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Actual numeric value of the card 2 (Two) to 14 (Ace)
        /// </summary>
        public int NumericValue { get; set; }

        /// <summary>
        /// Suit of the card
        /// </summary>
        public Suit Suit { get; set; }
        public Card()
        {

        }
        /// <summary>
        /// Initializes a new card
        /// </summary>
        /// <param name="numericValue">Numeric Value of the Card</param>
        /// <param name="suit">Suit of the Card</param>
        public Card(int numericValue, Suit suit)
        {
            this.NumericValue = numericValue;
            this.Suit = suit;
        }

        /// <summary>
        /// Face value of the card
        /// </summary>
        /// <returns>Card Description</returns>
        public string FaceValue()
        {
            return this.GetCardDescription();
        }
    }
}
