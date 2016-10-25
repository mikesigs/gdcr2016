using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class Tests
    {
        [Fact]
        public void Game_with_no_starting_coords_has_no_live_cells()
        {
            // Arrange
            var seed = new Coords[0];

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Any().ShouldBeFalse();
        }

        [Fact]
        public void Game_with_one_starting_coords_has_nine_cells()
        {
            // Arrange
            var seed = new[]
            {
                new Coords(0, 0)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count().ShouldBe(9);
        }

        [Fact]
        public void Game_with_one_starting_coords_has_1_live_cell()
        {
            // Arrange
            var seed = new[]
            {
                new Coords(0, 0)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => c.IsAlive).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_1_live_cell_with_coords_matching_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new []
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => c.IsAlive && c.X == x && c.Y == y).ShouldBe(1);
        }

        [Fact]
        public void Game_with_one_starting_coords_has_8_empty_cells()
        {
            // Arrange
            var seed = new[]
            {
                new Coords(0,0)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive).ShouldBe(8);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_NW_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x - 1 && c.Y == y - 1).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_N_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x && c.Y == y - 1).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_NE_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x && c.Y == y - 1).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_E_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x - 1 && c.Y == y).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_W_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x + 1 && c.Y == y).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_SW_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x - 1 && c.Y == y + 1).ShouldBe(1);
        }

        [Theory]
        [InlineData(-0, -1)]
        [InlineData(-1, -0)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        public void Game_with_one_starting_coords_has_an_empty_cell_to_the_S_of_the_starting_coords(int x, int y)
        {
            // Arrange
            var seed = new[]
            {
                new Coords(x, y)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count(c => !c.IsAlive && c.X == x && c.Y == y + 1).ShouldBe(1);
        }

        [Theory]
        [InlineData(new [] { 1, 1 }, "---\n-.-\n---\n")]
        [InlineData(new [] { 0, 1 }, "---\n-.-\n---\n")]
        public void Can_draw_game_state(int[] coords, string expectedState)
        {
            // Arrange
            var seed = new []
            {
                new Coords(coords[0], coords[1])
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Draw().ShouldBe(expectedState);
        }
    }

    public class Game
    {
        public static Game Create(IEnumerable<Coords> seed)
        {
            return new Game(seed);
        }

        private Game(IEnumerable<Coords> liveCellCoords)
        {
            Cells = liveCellCoords.SelectMany(liveCell => new[]
                                  {
                                      new Cell { IsAlive = true, X = liveCell.X, Y = liveCell.Y },  // Live Cell
                                      new Cell { X = liveCell.X - 1, Y = liveCell.Y - 1 },          // NW
                                      new Cell { X = liveCell.X, Y = liveCell.Y - 1 },              // N
                                      new Cell { X = liveCell.X + 1, Y = liveCell.Y - 1 },          // NE
                                      new Cell { X = liveCell.X - 1, Y = liveCell.Y },              // E
                                      new Cell { X = liveCell.X + 1, Y = liveCell.Y },              // W
                                      new Cell { X = liveCell.X - 1, Y = liveCell.Y + 1},           // SW
                                      new Cell { X = liveCell.X, Y = liveCell.Y + 1},               // S
                                      new Cell { X = liveCell.X + 1, Y = liveCell.Y + 1}            // SE
                                  }).ToList();
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
    }

    public class Cell
    {
        public Cell NW { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
    }

    public class Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
