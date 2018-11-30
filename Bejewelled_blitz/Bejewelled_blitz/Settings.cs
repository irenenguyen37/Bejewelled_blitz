using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejewelled_blitz
{
     public class Settings
    {
        //x tengely mérete
        public static int xTg = 79;
        //y tengely mérete
        public static int yTg = 24;
        //Színek száma
        public static int Color = 1;

        public static void sttngs()
        {
            if (Console.LargestWindowHeight < 40)
            {
                Console.WindowHeight = Console.LargestWindowHeight;
            }
            else
            {
                Console.WindowHeight = 40;
            }

            if (Console.LargestWindowWidth < 170)
            {
                Console.WindowWidth = Console.LargestWindowWidth;
            }
            else
            {
                Console.WindowWidth = 170;
            }
        }
        public static void Color1(int a)
        {
            if (a % 2 == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Color2(int a)
        {
            switch (a)
            {
                case 1:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 4:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 5:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 6:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
    }
}
