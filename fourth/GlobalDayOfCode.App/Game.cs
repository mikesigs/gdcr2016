using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobalDayOfCode.App
{
    public class Game
    {
        public static Game Create(IEnumerable<Coords> seed)
        {
            return new Game(seed);
        }

        private Game(IEnumerable<Coords> liveCellCoords)
        {
            var liveCellCoordsList = liveCellCoords.ToList();

            Cells = liveCellCoordsList
                .SelectMany(coords => new[]
                {
                    coords,
                    new Coords(coords.X - 1, coords.Y - 1), // NW
                    new Coords(coords.X, coords.Y - 1), // N
                    new Coords(coords.X + 1, coords.Y - 1), // NE
                    new Coords(coords.X - 1, coords.Y), // E
                    new Coords(coords.X + 1, coords.Y), // W
                    new Coords(coords.X - 1, coords.Y + 1), // SW
                    new Coords(coords.X, coords.Y + 1), // S
                    new Coords(coords.X + 1, coords.Y + 1) // SE
                })
                .Distinct()
                .Select(c => new Cell(
                    c.X, 
                    c.Y, 
                    isAlive: liveCellCoordsList.Any(coords => coords.X == c.X && coords.Y == c.Y), 
                    board: Cells));
        }

        public IEnumerable<Cell> Cells { get; }

        public string Draw()
        {
            var minY = Cells.Min(c => c.Y);
            var maxY = Cells.Max(c => c.Y);
            var minX = Cells.Min(c => c.X);
            var maxX = Cells.Max(c => c.X);
            var height = Math.Abs(minY) + Math.Abs(maxY) + 1;
            var width = Math.Abs(minX) + Math.Abs(maxX) + 1;

            var startingBoard = new char[height][];
            for (var i = 0; i < height; i++)
            {
                var z = startingBoard[i] = new string(' ', width).ToCharArray();
            }

            return Cells
                .Aggregate(startingBoard, (board, cell) =>
                {
                    board[cell.Y + Math.Abs(minY)][cell.X + Math.Abs(minX)] = cell.IsAlive ? '.' : '-';
                    return board;
                })
                .Aggregate("", (board, line) => board + string.Join("", line) + "\n");
        }

        public Game Evolve()
        {
            var liveCellCoordsAfterEvolution = Cells
                .Aggregate(new Coords[0], (acc, cell) =>
                {
                    if (IsAliveWithTwoOrThreeLiveNeighbours(cell) || 
                        IsDeadCellWithExactlyThreeLiveNeighbours(cell))
                    {
                        return acc.Concat(new[]
                                  {
                                      new Coords(cell.X, cell.Y)
                                  }).ToArray();
                    }
                    return acc;
                });

            return new Game(liveCellCoordsAfterEvolution);
        }
        
        private static bool IsDeadCellWithExactlyThreeLiveNeighbours(Cell cell)
        {
            return !cell.IsAlive && cell.LiveNeighbourCount == 3;
        }

        private static bool IsAliveWithTwoOrThreeLiveNeighbours(Cell cell)
        {
            return cell.IsAlive && (cell.LiveNeighbourCount == 2 || cell.LiveNeighbourCount == 3);
        }
    }
}