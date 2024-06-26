﻿using System;

namespace GemHunters
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Player
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }
        public void Move(char direction)
        {
            switch (direction)
            {
                case 'U': Position.Y = Math.Max(0, Position.Y - 1); break;
                case 'D': Position.Y = Math.Min(5, Position.Y + 1); break;
                case 'L': Position.X = Math.Max(0, Position.X - 1); break;
                case 'R': Position.X = Math.Min(5, Position.X + 1); break;
            }

        }
        class Cell
        {
            public string Occupant { get; set; }

            public Cell()
            {
                Occupant = "-";
            }
        }

        class Board
        {
            public Cell[,] Grid { get; set; }
            private static Random rand = new Random();

            public Board(Player player1, Player player2)
            {
                Grid = new Cell[6, 6];
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Grid[i, j] = new Cell();
                    }
                }

                // Place players
                Grid[player1.Position.Y, player1.Position.X].Occupant = "P1";
                Grid[player2.Position.Y, player2.Position.X].Occupant = "P2";

                // Place gems
                PlaceRandomElements("G", 5);

                // Place obstacles
                PlaceRandomElements("O", 5);
            }

            private void PlaceRandomElements(string element, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    int x, y;
                    do
                    {
                        x = rand.Next(6);
                        y = rand.Next(6);
                    } while (Grid[y, x].Occupant != "-");

                    Grid[y, x].Occupant = element;
                }
            }

            public void Display()
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        Console.Write(Grid[i, j].Occupant + " ");
                    }
                    Console.WriteLine();
                }
            }

            public bool IsValidMove(Player player, char direction)
            {
                int newX = player.Position.X;
                int newY = player.Position.Y;

                switch (direction)
                {
                    case 'U': newY--; break;
                    case 'D': newY++; break;
                    case 'L': newX--; break;
                    case 'R': newX++; break;
                }

                if (newX < 0 || newX >= 6 || newY < 0 || newY >= 6)
                    return false;
                if (Grid[newY, newX].Occupant == "O")
                    return false;

                return true;
            }

            public void CollectGem(Player player)
            {
                if (Grid[player.Position.Y, player.Position.X].Occupant == "G")
                {
                    player.GemCount++;
                    Grid[player.Position.Y, player.Position.X].Occupant = "-";
                }
            }
            class Game
            {
                private Board board;
                private Player player1;
                private Player player2;
                private Player currentPlayer;
                private int totalTurns;

                public Game()
                {
                    player1 = new Player("P1", new Position(0, 0));
                    player2 = new Player("P2", new Position(5, 5));
                    board = new Board(player1, player2);
                    currentPlayer = player1;
                    totalTurns = 0;
                }

                public void Start()
                {
                    while (!IsGameOver())
                    {
                        Console.Clear();
                        board.Display();
                        Console.WriteLine($"{currentPlayer.Name}'s turn. Enter move (U, D, L, R): ");
                        char move = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        if (board.IsValidMove(currentPlayer, move))
                        {
                            board.Grid[currentPlayer.Position.Y, currentPlayer.Position.X].Occupant = "-";
                            currentPlayer.Move(move);
                            board.CollectGem(currentPlayer);
                            board.Grid[currentPlayer.Position.Y, currentPlayer.Position.X].Occupant = currentPlayer.Name;
                            totalTurns++;
                            SwitchTurn();
                        }
                        else
                        {
                            Console.WriteLine("Unauthorized movement! Make another attempt.");
                        }
                    }

                    AnnounceWinner();
                }

                private void SwitchTurn()
                {
                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }

                private bool IsGameOver()
                {
                    return totalTurns >= 30;
                }

                private void AnnounceWinner()
                {
                    Console.Clear();
                    board.Display();
                    Console.WriteLine("End of Game!");
                    Console.WriteLine($"P1 Gems: {player1.GemCount}");
                    Console.WriteLine($"P2 Gems: {player2.GemCount}");
                    if (player1.GemCount > player2.GemCount)
                    {
                        Console.WriteLine("Winner is Player1!");
                    }
                    else if (player1.GemCount < player2.GemCount)
                    {
                        Console.WriteLine("Winner is Player2!");
                    }
                    else
                    {
                        Console.WriteLine("It's a draw!");
                    }
                }
            }
            class Program
            {
                static void Main(string[] args)
                {
                    Game game = new Game();
                    game.Start();
                }
            }
        }
    }
    }
  