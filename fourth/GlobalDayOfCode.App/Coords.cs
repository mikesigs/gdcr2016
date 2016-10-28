using System;

namespace GlobalDayOfCode.App
{
    public class Coords : IEquatable<Coords>
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool Equals(Coords other)
        {
            if (other == null) return false;
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals((Coords) obj);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}