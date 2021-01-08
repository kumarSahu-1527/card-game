using CardGame.Helpers.ExtensionMethods;
using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.Helpers
{
    /// <summary>
    /// Handles all game behaviours
    /// </summary>
    public class GameMaster
    {
        /// <summary>
        /// Players playing the game
        /// </summary>
        public Player[] Players { get; set; }

        /// <summary>
        /// Turn index to utilize in multi player game, if game rules change
        /// </summary>
        public int PlayerTurnIndex { get; set; }

        /// <summary>
        /// Active player count whose cards have not been finished
        /// </summary>
        public int ActivePlayers { get; set; }

        /// <summary>
        /// Total player count in the game
        /// </summary>
        public int PlayerCount { get; set; }
        public GameMaster()
        {

        }

        /// <summary>
        /// Initializes new game
        /// </summary>
        /// <param name="playerNames">Player List</param>
        public GameMaster(string[] playerNames)
        {
            this.PlayerCount = playerNames.Length;
            this.Players = new Player[this.PlayerCount];
            for(int i = 0; i < this.PlayerCount; i++)
            {
                Players[i] = new Player(playerNames[i]);
                Console.WriteLine("Player {0}: {1}", i, playerNames[i]);
            }
            Console.WriteLine("{0} is dealing...", Players[0].Name);
            this.Deal();
        }

        /// <summary>
        /// Method to deal the cards among participants, could be well optimized if game rule changes
        /// </summary>
        /// <returns>Success Indicator</returns>
        private bool Deal()
        {
            try
            {
                Queue<Card> deck = DeckMaster.NewDeck();
                this.ActivePlayers = this.PlayerCount;
                int playerIndex = 1; //Next player to the dealer (index: 0)
                while (deck.Any())
                {
                    Players[playerIndex % this.PlayerCount].Deck.Enqueue(deck.Dequeue());
                    playerIndex++;
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Method to check if the game is still on or not
        /// </summary>
        /// <returns>Success Indicator</returns>
        public bool IsEndOfGame()
        {
            try
            {
                if(this.ActivePlayers < 1)
                {
                    return true;
                }
                else {
                    for (int i = 0; i < this.Players.Length; i++)
                    {
                        if (this.Players[i].isActive && !this.Players[i].Deck.Any())
                        {
                            this.Players[i].isActive = false;
                            this.ActivePlayers -= 1;
                            if (this.ActivePlayers == 0)
                            {
                                Console.WriteLine(Players[i].Name + " has won the game...");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine(Players[i].Name + " is out of cards, removing from the game...");
                            }
                        }
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// Method to play turn, could be well changed if game rule changes
        /// </summary>
        /// <returns>Success Indicator</returns>
        public bool PlayTurn()
        {
            try
            {
                int i = 1;
                while (i <= this.PlayerCount)
                {
                    if (this.Players[i % this.PlayerCount].isActive)
                    {
                        Card playedCard = this.Players[i % this.PlayerCount].Deck.Dequeue();
                        Console.WriteLine(this.Players[i % this.PlayerCount].Name + " played " + playedCard.FaceValue());
                    }
                    i++;
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while playing the turn!");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Abandoing the game!");
                return false;
            }
        }

        /// <summary>
        /// Method to restart the game without among same players
        /// </summary>
        /// <returns>Success Indicator</returns>
        public bool RestartGame()
        {
            try
            {
                Console.WriteLine("Restarting the game...");
                for (int i = 0; i < this.PlayerCount; i++)
                {
                    Players[i].isActive = true;
                    Players[i].Deck = new Queue<Card>();
                }
                Console.WriteLine("{0} is dealing...", Players[0].Name);
                this.Deal();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Restart failed. Please start over with new game...");
                return false;
            }
        }

        /// <summary>
        /// Method to shuffle the cards/deck
        /// </summary>
        /// <param name="playerName">Optional player name to shuffle their cards only else will shuffle each players card</param>
        /// <returns>Success Indicator</returns>
        public bool ShuffleDeck(string playerName = "")
        {
            try
            {
                if(playerName != "")
                {
                    IEnumerable<Player> players = this.Players.Where(player => player.Name.ToLower() == playerName.ToLower());
                    for (int i = 0; i < players.Count(); i++)
                    {
                        if (this.Players[i].isActive)
                        {
                            this.Players[i].Deck.Shuffle();
                            Console.WriteLine("Player {0}: Cards Shuffled", this.Players[i].Name);
                        }
                        else
                        {
                            Console.WriteLine("Player {0}: Has no cards to shuffle", this.Players[i].Name);
                        }
                    }
                }
                else
                {
                    if(this.ActivePlayers > 0)
                    {
                        Console.WriteLine("Shuffling the cards:");
                        for (int i = 0; i < this.PlayerCount; i++)
                        {
                            if (this.Players[i].isActive)
                            {
                                this.Players[i].Deck.Shuffle();
                                Console.WriteLine("Player {0}: Cards Shuffled", this.Players[i].Name);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Game has been ended. start over...");
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Shuffle Cards failed. Please start over with new game...");
                return false;
            }
        }
    }
}
