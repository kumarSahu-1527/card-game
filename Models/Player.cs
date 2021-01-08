using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Helpers
{
    /// <summary>
    /// Handles all player behaviours
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Staus of player if he's still in the game or not
        /// </summary>
        public bool isActive { get; set; }

        /// <summary>
        /// Player deck
        /// </summary>
        public Queue<Card> Deck { get; set; }

        public Player()
        {

        }
        /// <summary>
        /// Initializes a new player
        /// </summary>
        /// <param name="name">Player Name</param>
        public Player(string name)
        {
            this.Name = name;
            this.isActive = true;
            this.Deck = new Queue<Card>();
        }
    }
}
