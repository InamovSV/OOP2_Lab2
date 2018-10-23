using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cu = new ControlUnit();
            var p1 = new Player("serg", "");
            var game = new Game(cu, p1, 10, 10);
            game.Start();
            while (true)
            {
                var c = Console.ReadKey().Key;
                switch (c)
                {
                    case ConsoleKey.LeftArrow:
                        game.ClickLeft();
                        break;
                    case ConsoleKey.UpArrow:
                        game.ClickUp();
                        break;
                    case ConsoleKey.RightArrow:
                        game.ClickRight();
                        break;
                    case ConsoleKey.DownArrow:
                        game.ClickDown();
                        break;
                    case ConsoleKey.Z:
                        game.Undo(1);
                        break;
                    case ConsoleKey.X:
                        game.Redo(1);
                        break;
                    default:
                        break;
                }
            }
            

            Console.ReadLine();
        }
        
       
    }
}
