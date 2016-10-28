using System.Collections.Generic;
using System.Linq;
using GlobalDayOfCode.App;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class NeighbourTests
    {
        [Theory]
        [MemberData(nameof(NeighbourData))]
        public void Each_live_cell_has_8_neighbours(Coords[] seed)
        {
            // Arrange

            // Act
            var game = Game.Create(seed);

            // Assert
            var liveCells = game.Cells.Where(c => c.IsAlive);
            liveCells.ShouldAllBe(c => c.NeighbourCount == 8);
        }

        [Fact]
        public void Non_live_neighbour_cells_may_have_less_than_8_neighbours()
        {
            // Arrange
            var seed = new[]
            {
                new Coords(0, 0)
            };

            // Act
            var game = Game.Create(seed);

            // Assert
            var nonLiveNeighbour = game.Cells.First(c => !c.IsAlive);
            nonLiveNeighbour.NeighbourCount.ShouldNotBe(8);
        }

        public static IEnumerable<object[]> NeighbourData => new[]
        {
            new object[]
            {
                new[]
                {
                    new Coords(0, 0)
                }
            },
            new object[]
            {
                new[]
                {
                    new Coords(0, 0),
                    new Coords(0, 1),
                    new Coords(0, 5),
                }
            },
        };
    }
}