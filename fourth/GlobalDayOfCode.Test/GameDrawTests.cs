using System.Collections.Generic;
using GlobalDayOfCode.App;
using Shouldly;
using Xunit;

namespace GlobalDayOfCode.Test
{
    public class GameDrawTests
    {
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
}