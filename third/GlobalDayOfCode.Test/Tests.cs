using System.Collections;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class Tests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Living_cell_with_less_than_2_neighbours_dies(int neighbours)
        {
            // Arrange
            var cell = new LivingCell();

            // Act
            var newCell = cell.Evolve(neighbours);

            // Assert
            newCell.ShouldBeOfType<EmptyCell>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Dead_cell_with_less_than_3_neighbours_stays_dead(int neighbours)
        {
            // Arrange
            var cell = new EmptyCell();

            // Act
            var newCell = cell.Evolve(neighbours);

            // Assert
            newCell.ShouldBeOfType<EmptyCell>();
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void Dead_cell_with_greater_than_3_neighbours_stays_dead(int neighbours)
        {
            // Arrange
            var cell = new EmptyCell();

            // Act
            var newCell = cell.Evolve(neighbours);

            // Assert
            newCell.ShouldBeOfType<EmptyCell>();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Living_cell_with_2_or_3_neighbours_lives(int neighbours)
        {
            // Arrange
            var cell = new LivingCell();

            // Act
            var newCell = cell.Evolve(neighbours);

            // Assert
            newCell.ShouldBeOfType<LivingCell>();
        }
        
        [Fact]
        public void Dead_cell_with_3_neighbours_is_born()
        {
            // Arrange
            var cell = new EmptyCell();

            // Act
            var newCell = cell.Evolve(3);

            // Assert
            newCell.ShouldBeOfType<LivingCell>();
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void Living_cell_with_4_or_more_neighbours_dies(int neighbours)
        {
            // Arrange
            var cell = new EmptyCell();

            // Act
            var newCell = cell.Evolve(neighbours);

            // Assert
            newCell.ShouldBeOfType<EmptyCell>();
        }

        [Fact]
        public void A_board_exists()
        {
            // Arrange
            var board = new Board();

            // Act


            // Assert
            board.ShouldNotBeNull();
        }

        [Fact]
        public void A_board_has_a_collection_of_cells()
        {
            // Arrange
            var board = new Board();

            // Act


            // Assert
            board.Cells.ShouldNotBeEmpty();
        }
    }

    public class Board
    {
        public IList<Cell> Cells { get; set; }
    }

    public class EmptyCell : Cell
    {
        public override Cell Evolve(int neighbours)
        {
            if (neighbours == 3)
            {
                return new LivingCell();
            }

            return new EmptyCell();
        }

        public object X { get; set; }
    }

    public class LivingCell : Cell
    {
        public override Cell Evolve(int neighbours)
        {
            if (neighbours == 2 || neighbours == 3)
            {
                return new LivingCell();
            }

            return new EmptyCell();
        }
    }

    public abstract class Cell
    {
        public abstract Cell Evolve(int neighbours);
    }
}
