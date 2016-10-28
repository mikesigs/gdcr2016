using System.Linq;
using System.Net.Http.Headers;
using GlobalDayOfCode.App;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class EvolutionTests
    {
        [Fact]
        public void Live_cell_with_no_live_neighbours_dies()
        {
            // Arrange
            var targetCoords = new Coords(0, 0);
            var seed = new[]
            {
                targetCoords
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            evolvedCell.ShouldBeNull();
        }

        [Fact]
        public void Live_cell_with_one_live_neighbours_dies()
        {
            // Arrange
            var targetCoords = new Coords(0, 0);
            var seed = new[]
            {
                targetCoords,
                new Coords(0, 1)
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            evolvedCell.ShouldBeNull();
        }

        [Fact]
        public void Live_cell_with_two_live_neighbours_lives()
        {
            // Arrange
            // ---  ==>       
            // -.-  ==>  -----
            // -.-  ==>  -...-
            // -.-  ==>  -----
            // ---  ==>       
            var targetCoords = new Coords(0, 1);
            var seed = new[]
            {
                new Coords(0, 0), targetCoords, new Coords(0, 2),
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull(),
                () => evolvedCell.IsAlive.ShouldBeTrue(),
                () => game.Draw().ShouldBe("-----\n" +
                                           "-...-\n" +
                                           "-----\n"));
        }

        [Fact]
        public void Live_cell_with_three_live_neighbours_lives()
        {
            // Arrange
            // ----  ==>   ----
            // -.--  ==>  --..-
            // -..-  ==>  -...-
            // -.--  ==>  --..-
            // ----  ==>   ----
            var targetCoords = new Coords(0, 1);
            var seed = new[]
            {
                new Coords(0, 0), targetCoords, new Coords(0, 2), new Coords(1, 1), 
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull(),
                () => evolvedCell.IsAlive.ShouldBeTrue(),
                () => game.Draw().ShouldBe(" ----\n" +
                                           "--..-\n" +
                                           "-...-\n" +
                                           "--..-\n" +
                                           " ----\n"));
        }

        [Fact]
        public void Dead_cell_with_exactly_three_live_neighbours_is_born()
        {
            // Arrange
            // ----  ==>  ----
            // -..-  ==>  -..-
            // -.--  ==>  -..-
            // ---   ==>  ----
            var seed = new[]
            {
                new Coords(0, 0), 
                new Coords(1, 0),
                new Coords(0, 1)
            };
            var targetCoords = new Coords(1,1);

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull(),
                () => evolvedCell.IsAlive.ShouldBeTrue(),
                () => game.Draw().ShouldBe("----\n" +
                                           "-..-\n" +
                                           "-..-\n" +
                                           "----\n"));
        }

        [Fact]
        public void Live_cell_with_four_live_neighbours_dies()
        {
            // Arrange
            //     012
            // -2        ==>   --- 
            // -1 -----  ==>  --.--
            //  0 -...-  ==>  -.-.-
            //  1 -.-.-  ==>  -.-.-
            //  2 -----  ==>  -----
            var targetCoords = new Coords(1, 0);
            var seed = new[]
            {
                new Coords(0, 0),
                targetCoords,
                new Coords(2, 0),
                new Coords(0, 1),
                new Coords(2, 1)
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull("Because it's still another live cell's neighbour"),
                () => evolvedCell.IsAlive.ShouldBeFalse(),
                () => game.Draw().ShouldBe(" --- \n" +
                                           "--.--\n" +
                                           "-.-.-\n" +
                                           "-.-.-\n" +
                                           "-----\n"));
        }

        [Fact]
        public void Live_cell_with_five_live_neighbours_dies()
        {
            // Arrange
            //     012
            // -2 -----  ==>   ---
            // -1 -----  ==>  --.--
            //  0 -...-  ==>  -.-.-
            //  1 -...-  ==>  -.-.-
            //  2 -----  ==>  --.--
            //  3 -----  ==>   ---
            var targetCoords = new Coords(1, 0);
            var seed = new[]
            {
                new Coords(0, 0),
                targetCoords,
                new Coords(2, 0),
                new Coords(0, 1),
                new Coords(1, 1),
                new Coords(2, 1)
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull("Because it's still another live cell's neighbour"),
                () => evolvedCell.IsAlive.ShouldBeFalse(),
                () => game.Draw().ShouldBe(" --- \n" +
                                           "--.--\n" +
                                           "-.-.-\n" +
                                           "-.-.-\n" +
                                           "--.--\n" +
                                           " --- \n"));
        }

        [Fact]
        public void Live_cell_with_six_live_neighbours_dies()
        {
            // Arrange
            //     012
            // -2        ==>   --- 
            // -1 -----  ==>  --.--
            //  0 -...-  ==>  -.-.-
            //  1 -...-  ==>  .--.-
            //  2 -.---  ==>  -.---
            //  3        ==>   --- 
            var targetCoords = new Coords(1, 1);
            var seed = new[]
            {
                new Coords(0, 0),
                new Coords(1, 0),
                new Coords(2, 0),
                new Coords(0, 1),
                targetCoords,
                new Coords(2, 1),
                new Coords(0, 2),
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull("Because it's still another live cell's neighbour"),
                () => evolvedCell.IsAlive.ShouldBeFalse(),
                () => game.Draw().ShouldBe("  --- \n" +
                                           " --.--\n" +
                                           "--.-.-\n" +
                                           "-.--.-\n" +
                                           "--.---\n" +
                                           " ---  \n"));
        }

        [Fact]
        public void Live_cell_with_seven_live_neighbours_dies()
        {
            // Arrange
            //     012
            // -2        ==>    --- 
            // -1 -----  ==>   --.--
            //  0 -...-  ==>  --.-.-
            //  1 -...-  ==>  -.----
            //  2 -..--  ==>  --.-.- 
            //  3 -----  ==>   -----       
            var targetCoords = new Coords(1, 1);
            var seed = new[]
            {
                new Coords(0, 0),
                new Coords(1, 0),
                new Coords(2, 0),
                new Coords(0, 1),
                targetCoords,
                new Coords(2, 1),
                new Coords(0, 2),
                new Coords(1, 2),
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull("Because it's still another live cell's neighbour"),
                () => evolvedCell.IsAlive.ShouldBeFalse(),
                () => game.Draw().ShouldBe("  --- \n" +
                                           " --.--\n" +
                                           "--.-.-\n" +
                                           "-.----\n" +
                                           "--.-.-\n" +
                                           " -----\n"));
        }

        [Fact]
        public void Live_cell_with_eight_live_neighbours_dies()
        {
            // Arrange
            //     012
            // -2        ==>    ---  
            // -1 -----  ==>   --.-- 
            //  0 -...-  ==>  --.-.--
            //  1 -...-  ==>  -.---.-
            //  2 -...-  ==>  --.-.--
            //  3 -----  ==>   --.-- 
            //  4        ==>    ---  
            var targetCoords = new Coords(1, 1);
            var seed = new[]
            {
                new Coords(0, 0),
                new Coords(1, 0),
                new Coords(2, 0),
                new Coords(0, 1),
                targetCoords,
                new Coords(2, 1),
                new Coords(0, 2),
                new Coords(1, 2),
                new Coords(2, 2),
            };

            // Act
            var game = Game.Create(seed).Evolve();

            // Assert
            var evolvedCell = GetCell(game, targetCoords);
            game.ShouldSatisfyAllConditions(
                () => evolvedCell.ShouldNotBeNull("Because it's still another live cell's neighbour"),
                () => evolvedCell.IsAlive.ShouldBeFalse(),
                () => game.Draw().ShouldBe("  ---  \n" +
                                           " --.-- \n" +
                                           "--.-.--\n" +
                                           "-.---.-\n" +
                                           "--.-.--\n" +
                                           " --.-- \n" +
                                           "  ---  \n"));
        }

        private static Cell GetCell(Game game, Coords coords)
        {
            return game.Cells.SingleOrDefault(c => c.X == coords.X && c.Y == coords.Y);
        }
    }
}