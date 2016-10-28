using System.Collections.Generic;
using System.Linq;

namespace GlobalDayOfCode.App
{
    public class Cell
    {
        private readonly IEnumerable<Cell> _neighbours;

        public Cell(int x, int y, bool isAlive, IEnumerable<Cell> board)
        {
            X = x;
            Y = y;
            IsAlive = isAlive;
            _neighbours = board.Where(IsNeighbour);
        }

        public int X { get; }

        public int Y { get; }

        public bool IsAlive { get; }

        public int NeighbourCount => _neighbours.Count();

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
