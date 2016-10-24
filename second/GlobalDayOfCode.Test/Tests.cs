using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class Tests
    {
        //Live cell with 1 neighbour dies
        [Fact]
        public void Live_cell_with_1_neighbour_dies()
        {
            // Arrange
            var cell = new LivingCell();

            // Act
            var newCell = cell.Evolve(1);

            // Assert
            newCell.IsAlive.ShouldBe(false);
        }

        //Live cell with 2 neighbours lives
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Live_cell_with_2_or_3_neighbours_lives(int neighbourCount)
        {
            // Arrange
            var cell = new LivingCell();

            // Act
            var newCell = cell.Evolve(neighbourCount);

            // Assert
            newCell.ShouldBeOfType<LivingCell>();
        }


        [Fact]
        public void Dead_cell_with_2_neighbours_stays_dead()
        {
            // Arrange
            var cell = new DeadCell();

            // Act
            var newCell = cell.Evolve(2);

            // Assert
            newCell.ShouldBeOfType<DeadCell>();
        }

        //Dead cell with 3 neighbours is born
        [Fact]
        public void Dead_cell_with_3_neighbours_is_born()
        {
            // Arrange
            var cell = new DeadCell();

            // Act
            var newCell = cell.Evolve(3);

            // Assert
            newCell.ShouldBeOfType<LivingCell>();
        }

        //Live cell with more than 4 dies
        // Dead cell with x neighbours lives or dies
    }

    public class LivingCell : Cell
    {
        public LivingCell()
        {
            IsAlive = true;
        }

        public override bool IsAlive { get; }

        public override Cell Evolve(int liveNeighbours)
        {
            if (liveNeighbours == 2 || liveNeighbours == 3)
            {
                return new LivingCell();
            }
            else
            {
                return new DeadCell();
            }
        }
    }

    public class DeadCell : Cell
    {
        public DeadCell()
        {
            IsAlive = false;
        }

        public override bool IsAlive { get; }

        public override Cell Evolve(int liveNeighbours)
        {
            if (liveNeighbours == 3)
            {
                return new LivingCell();
            }
            else
            {
                return new DeadCell();
            }
        }
    }

    public abstract class Cell
    {
        protected Cell()
        {
        }

        public abstract bool IsAlive { get; }

        public abstract Cell Evolve(int liveNeighbours);
    }
}
