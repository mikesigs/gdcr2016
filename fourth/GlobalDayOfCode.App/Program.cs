using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GlobalDayOfCode.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var block = new[]
            {
                new Coords(0, 0),
                //new Coords(1, 0),
                new Coords(2, 0),
                new Coords(0, 1),
                new Coords(1, 1),
                new Coords(2, 1),
                new Coords(0, 2),
                new Coords(1, 2),
                new Coords(2, 2)
            };

            var iterations = 0;
            var game = Game.Create(block);

            do
            {
                Console.Clear();
                Console.Write(game.Draw('.', ' '));
                game = game.Evolve();
                iterations++;
                Thread.Sleep(250);
            } while (game.Cells.Any());

            Console.WriteLine($"Game ran for {iterations} iterations.");
            Console.WriteLine("Press any key to exit.");
        }
    }
}
