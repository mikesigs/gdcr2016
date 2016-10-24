using System.Linq;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class Tests
    {
        /*
         * Live Entity with 1 neighbor dies
         * Live Entity with 2 neighbors lives
         * Live Entity with 3 neighbours lives
         * Dead Entity with 3 neighbours is born
         * Live Entity with more than 3 neighbours dies
         */

        [Theory]
        [InlineData(CellState.Alive)]
        [InlineData(CellState.Dead)]
        public void Cell_state_can_be_defined(CellState state)
        {
            // Arrange
            var cell = new Cell(state);

            // Act


            // Assert
            cell.State.ShouldBe(state);
        }
        
        [Fact]
        public void Live_cell_with_1_neighbour_dies()
        {
            // Arrange
            var cell = new Cell(CellState.Alive);

            // Act
            var newCell = cell.Evolve(1);

            // Assert
            newCell.State.ShouldBe(CellState.Dead);
        }

        [Fact]
        public void Live_cell_with_2_neighbours_lives()
        {
            // Arrange
            var cell = new Cell(CellState.Alive);

            // Act
            var newCell = cell.Evolve(2);

            // Assert
            newCell.State.ShouldBe(CellState.Alive);
        }

        [Fact]
        public void Live_cell_with_3_neighbours_lives()
        {
            // Arrange
            var cell = new Cell(CellState.Alive);

            // Act
            var newCell = cell.Evolve(3);

            // Assert
            newCell.State.ShouldBe(CellState.Alive);
        }

        [Fact]
        public void Live_cell_with_4_neighbours_dies()
        {
            // Arrange
            var cell = new Cell(CellState.Alive);

            // Act
            var newCell = cell.Evolve(4);

            // Assert
            newCell.State.ShouldBe(CellState.Dead);
        }
    }

    public enum CellState
    {
        Alive = 1,
        Dead = 2
    }

    public class Cell
    {
        public Cell(CellState state)
        {
            this.State = state;
        }

        public CellState State { get; private set; }

        public Cell Evolve(int liveNeighbours)
        {
            CellState cellState = (CellState) 0;
            if (liveNeighbours == 2 || liveNeighbours == 3)
            {
                cellState = CellState.Alive;
            }

            return new Cell(cellState);
        }
    }
}
