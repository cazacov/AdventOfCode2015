using System;
using System.Collections.Generic;

namespace Day03
{
    class Program
    {
        static HashSet<Position>  visitedHouses = new HashSet<Position>();

        static void Main(string[] args)
        {
            var directions = System.IO.File.ReadAllText("radio.txt");
            
            var position = new Position(0, 0);
            visitedHouses.Add(position);

            foreach (var direction in directions)
            {

                position = position.Go(direction);
                visitedHouses.Add(position);
            }
            Console.WriteLine($"Santa delivered presents to {visitedHouses.Count} houses");
        }
    }

    class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public Position Go(char direction)
        {
            switch (direction)
            {
                case '^':
                    return new Position(X, Y + 1);
                    break;
                case 'v':
                    return new Position(X, Y - 1);
                    break;
                case '>':
                    return new Position(X + 1, Y);
                    break;
                case '<':
                    return new Position(X - 1, Y);
                    break;
            }

            throw new ArgumentOutOfRangeException(nameof(direction));
        }

        public readonly int X;
        public readonly int Y;
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
