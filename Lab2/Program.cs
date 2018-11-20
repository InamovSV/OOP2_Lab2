using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lab2.Items;
using System.Threading.Tasks;
using Lab2.Robots;

namespace Lab2
{
    public class Program
    {
        static void Main(string[] args)
        {
            var flag = true;
            var cu = new ControlUnit();
            var p1 = new Player("serg", "");
            var game = new Game(cu, p1, 10, 10);
            game.Start();
            while (flag)
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
                    case ConsoleKey.Enter:
                        game.TakeItem();
                        break;
                    case ConsoleKey.Z:
                        game.Undo(1);
                        break;
                    case ConsoleKey.X:
                        game.Redo(1);
                        break;
                    case ConsoleKey.Escape:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }

        }
        
       
    }
}
