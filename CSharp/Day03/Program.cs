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
            
            var santaPostion = new Position(0, 0);
            var roboSantaPosition = new Position(0, 0);
            visitedHouses.Add(santaPostion);


            bool santasTurn = true;
            foreach (var direction in directions)
            {
                if (santasTurn)
                {
                    santaPostion = santaPostion.Go(direction);
                    visitedHouses.Add(santaPostion);
                }
                else
                {
                    roboSantaPosition = roboSantaPosition.Go(direction);
                    visitedHouses.Add(roboSantaPosition);
                }
                santasTurn = !santasTurn;
            }
            Console.WriteLine($"Santa and his robot delivered presents to {visitedHouses.Count} houses");
        }
    }

    class Position
    {
        public readonly int X;
        public readonly int Y;

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

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
