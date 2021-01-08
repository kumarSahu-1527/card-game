using CardGame.Helpers;
using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentCommand = -1;
            string commandString = string.Empty;
            Console.WriteLine("Welcome to the Card-Game!!!");
            Console.WriteLine("Please use these keys to command the game:");
            Console.WriteLine("0: Help\t1: New Game\t2: Restart the Game\t3: Play a card/round\t4: Shuffle the deck\tCTRL+C: to exit the game");

            ConsoleKeyInfo cki;
            GameMaster gameMaster = null;
            do
            {
                cki = Console.ReadKey(true);
                if (!Char.IsNumber(cki.KeyChar))
                {
                    PrintHelp();
                }
                else
                {
                    if (Int32.TryParse(cki.KeyChar.ToString(), out currentCommand))
                    {
                        if (currentCommand == 1)
                        {
                            Console.WriteLine("Enter the comma separated player names...");
                            commandString = Console.ReadLine();
                            string[] playerNames = commandString.Split(',');
                            if (playerNames.Length > 52)
                            {
                                Console.WriteLine("Maximum 52 players allowed. Please start over...");
                            }
                            else
                            {
                                for (int i = 0; i < playerNames.Length; i++)
                                {
                                    playerNames[i] = playerNames[i].Trim();
                                }
                                gameMaster = new GameMaster(playerNames);
                            }
                        }
                        else if (currentCommand == 2)
                        {
                            if(gameMaster != null)
                            {
                                gameMaster.RestartGame();
                            }
                            else
                            {
                                Console.WriteLine("No game has been started. Please start with new game...");
                            }
                        }
                        else if (currentCommand == 3)
                        {
                            if (gameMaster != null)
                            {
                                if (!gameMaster.IsEndOfGame())
                                {
                                    gameMaster.PlayTurn();
                                }
                                else
                                {
                                    Console.WriteLine("Game has been ended.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No game has been started. Please start with new game...");
                            }
                        }
                        else if (currentCommand == 4)
                        {
                            if (gameMaster != null)
                            {
                                //Console.ReadLine(); -- to get the player name if needed
                                gameMaster.ShuffleDeck();
                            }
                            else
                            {
                                Console.WriteLine("No game has been started. Please start with new game...");
                            }
                        }
                        else
                        {
                            PrintHelp();
                        }
                    }
                    else
                    {
                        PrintHelp();
                    }
                }
            }
            while (cki.KeyChar != 27);
        }

        public static void PrintHelp()
        {
            Console.WriteLine("Please enter the right command value");
            Console.WriteLine("0: Help\t1: New Game\t2: Restart the Game\t3: Play a card/round\t4: Shuffle the deck\tCTRL+C: to exit the game");
        }
    }
}
