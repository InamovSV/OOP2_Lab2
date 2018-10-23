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
            var c = Console.ReadKey().Key;
            switch (c)
            {
                case ConsoleKey.LeftArrow:
                    Console.WriteLine("<-");
                    break;
                case ConsoleKey.UpArrow:
                    Console.WriteLine("/|\\");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("->");
                    break;
                case ConsoleKey.DownArrow:
                    Console.WriteLine("\\|/");
                    break;
                default:
                    break;
            }
            Console.WriteLine(c);
            Console.ReadLine();
        }

        public static async Task Execute(Action action, int timeoutInMilliseconds)
        {
            await Task.Delay(timeoutInMilliseconds);
            action();
        }
       
    }
}
