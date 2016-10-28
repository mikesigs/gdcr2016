using System.Collections.Generic;
using System.Linq;

namespace GlobalDayOfCode.App
{
    public class Cell
    {
        public Cell(int x, int y, bool isAlive, IEnumerable<Cell> board)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
            Neighbours = board.Where(IsNeighbour);
        }

        public int X { get; }

        public int Y { get; }

        public bool IsAlive { get; }

        public IEnumerable<Cell> Neighbours { get; }

        public int LiveNeighbourCount => Neighbours.Count(n => n.IsAlive);

        private bool IsNeighbour(Cell n)
        {
            return (n.Y == Y - 1 && n.X == X - 1) ||
                   (n.Y == Y - 1 && n.X == X) ||
                   (n.Y == Y - 1 && n.X == X + 1) ||
                   (n.Y == Y && n.X == X - 1) ||
                   (n.Y == Y && n.X == X + 1) ||
                   (n.Y == Y + 1 && n.X == X - 1) ||
                   (n.Y == Y + 1 && n.X == X) ||
                   (n.Y == Y + 1 && n.X == X + 1);
        }
    }
}
