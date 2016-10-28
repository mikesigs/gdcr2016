using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    /* 
     * A live cell knows all of its neighbours
     * An empty cell only knows it's live neighbours
     * Seed the game with a sequence of x, y coordinates. (edited)
     * Each coordinate denotes a live cell.
     * When creating a live cell, pass it a list of its 8 neighbors, living and empty.
     * The game maintains a list of all known cells,  living and dead.
     * When creating a new live cell, query the known cells list for it's neighbors, and instantiate and store any new empty neighbors. (edited)
     * Adding a neighbor to a live cell means the live cell is also added to the neighbour's neighbours list. (edited)
     * That complete the seed step.
     * Now each cell in the known cells list is told to evolve.
     * This returns a list of x, y coordinates of all remaining live cells.
     * The same process to seedbthe game will work to evolve it each time.
     */

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
        public void Game_with_one_starting_coords_has_9_cells()
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
        public void Game_with_two_adjacent_starting_Y_coords_has_12_cells()
        {
            // Arrange
            var seed = new[]
            {
                new Coords(0, 0),
                new Coords(0, 1)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count().ShouldBe(12);
        }

        [Fact]
        public void Game_with_three_adjacent_starting_Y_coords_has_15_cells()
        {
            // Arrange
            var seed = new[]
            {
                new Coords(0, 0),
                new Coords(0, 1),
                new Coords(0, 2)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Cells.Count().ShouldBe(15);
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
            var seed = new[]
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
                new Coords(0, 0)
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
        [MemberData(nameof(DrawStateData))]
        public void Can_draw_game_state(Coords[] seed, string expectedState)
        {
            // Arrange

            // Act
            var game = Game.Create(seed);

            // Assert
            game.Draw().ShouldBe(expectedState);
        }

        public static IEnumerable<object[]> DrawStateData => new[]
        {
            new object[]
            {
                new[]
                {
                    new Coords(0, 0)
                },
                "---\n" +
                "-.-\n" +
                "---\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 1)
                },
                "---\n" +
                "-.-\n" +
                "---\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(1, 0)
                },
                "---\n" +
                "-.-\n" +
                "---\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(1, 1)
                },
                "---\n" +
                "-.-\n" +
                "---\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 0), new Coords(0, 1)
                },
                "---\n" +
                "-.-\n" +
                "-.-\n" +
                "---\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 0), new Coords(1, 0)
                },
                "----\n" +
                "-..-\n" +
                "----\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 0), new Coords(2, 0),
                },
                "-----\n" +
                "-.-.-\n" +
                "-----\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 0), new Coords(0, 2),
                },
                "---\n" +
                "-.-\n" +
                "---\n" +
                "-.-\n" +
                "---\n"
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 0), new Coords(0, 2), new Coords(1, 2)
                },
                "--- \n" +
                "-.- \n" +
                "----\n" +
                "-..-\n" +
                "----\n"
            }
        };
    }

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
                .Select(c => new Cell
                {
                    X = c.X,
                    Y = c.Y,
                    IsAlive = liveCellCoordsList.Any(coords => coords.X == c.X && coords.Y == c.Y)
                });
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
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsAlive { get; set; }
    }

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
