﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejewelled_blitz
{
    public class Settings
    {
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

        public static int colors()
        {
            //színek száma
            int a = 5;
            return a+1;
        }

        public static int x()
        {
            //x tengely mérete
            int a = 20;
            return a;
        }

        public static int y()
        {
            //y tengely mérete
            int a = 10;
            return a;
        }
    }
}
