using System;

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
    }

}
   

