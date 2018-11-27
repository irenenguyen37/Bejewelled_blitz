using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejewelled_blitz
{
    public class Table
    {
        int[,] table;

        public Table(int a, int b, int n)
        {
            Random r = new Random();
            this.table = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                   table[i, j] = r.Next(1, n);
                }
            }
        }

        public void wrt()
        {
            Console.SetCursorPosition(0, 3);

            Console.Write("   ");
            int a = 1;

            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (a < 10)
                {
                    color1(a);
                    Console.Write(a + " ");
                }
                else
                {
                    color1(a);
                    Console.Write(a);
                }
                a++;
            }
            a = 1;
            Console.WriteLine();

            for (int i = 0; i < table.GetLength(0); i++)
            {
                color1(a);
                if (a < 10)
                    Console.Write(a + " ");
                else
                    Console.Write(a);
                color1(1);
                Console.Write(" ");

                for (int j = 0; j < table.GetLength(1); j++)
                {
                    color2(table[i, j]);
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
                a++;
            }
            color1(1);
            Console.WriteLine();
        }

        public static void color1(int a)
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

        static void color2(int a)
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

        public int[] chng()
        {
            int[] change = new int[4];
            int a = table.GetLength(0) - 1;
            int b = table.GetLength(1) - 1;
            Console.SetCursorPosition(0, a + 6);
            int clrS = 1;

            Console.WriteLine("Melyik két elemet szeretnéd felcserélni?");
            do
            {
                Console.Write("x1 (1-79): ");
                change[0] = int.Parse(Console.ReadLine()) - 1;
                clrS++;
            } while (change[0] > b || change[0] < 0);
            do
            {
                Console.Write("y1 (1-24): ");
                change[1] = int.Parse(Console.ReadLine()) - 1;
                clrS++;
            } while (change[1] > a || change[1] < 0);

            string d;
            do
            {
                Console.Write("Melyik irányba mozgassa? (w/a/s/d): ");
                d = Console.ReadLine();
                change[2] = change[0] + drctn(d)[0];
                change[3] = change[1] + drctn(d)[1];
                clrS++;
            } while (change[2] > b || change[2] < 0 || change[3] > a || change[3] < 0 || Math.Abs(change[0] - change[2]) + Math.Abs(change[1] - change[3]) > 1 || !(d == "w" || d == "a" || d == "s" || d == "d"));

            Clr(a + 6, clrS);

            int s = table[change[1], change[0]];
            table[change[1], change[0]] = table[change[3], change[2]];
            table[change[3], change[2]] = s;

            Console.SetCursorPosition(change[0] * 2 + 3, change[1] + 4);
            color2(table[change[1], change[0]]);
            Console.Write(table[change[1], change[0]] + " ");
            Console.SetCursorPosition(change[2] * 2 + 3, change[3] + 4);
            color2(table[change[3], change[2]]);
            Console.Write(table[change[3], change[2]] + " ");
            color1(1);

            return change;
        }

        int[] drctn(string d)
        {
            int[] a = new int[2];
            switch (d)
            {
                case "w":
                    a[0] = 0; a[1] = -1;
                    break;
                case "a":
                    a[0] = -1; a[1] = 0;
                    break;
                case "s":
                    a[0] = 0; a[1] = 1;
                    break;
                case "d":
                    a[0] = 1; a[1] = 0;
                    break;
                default:
                    break;
            }
            return a;
        }

        public void Clr(int c, int b)
        {
            int current = Console.CursorTop;
            for (int i = 0; i < b; i++)
            {
                Console.SetCursorPosition(0, c + i);
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, current);
        }

        public int pnt(int x, int y)
        {
            int[,] deleted = new int[2, table.GetLength(0) * table.GetLength(1)];
            int i = 0;
            int j = 0;
            deleted[0, i] = x;
            deleted[1, i] = y;

            int a = table[y, x];

            do
            {
                j = dlt(deleted, a, deleted[0, i], deleted[1, i], j);
                i++;
            } while (i < j + 1);
            if (j == 0)
            {
                table[y, x] = a;
                return j;
            }
            else
            {
                return j + 1;
            }
        }

        int dlt(int[,] deleted, int a, int x, int y, int j)
        {
            table[y, x] = 0;
            if (x - 1 >= 0)
            {
                if (table[y, x - 1] == a)
                {
                    j = rpt(deleted, j, x - 1, y);
                }
            }
            if (x + 1 < table.GetLength(1))
            {
                if (table[y, x + 1] == a)
                {
                    j = rpt(deleted, j, x + 1, y);
                }
            }
            if (y - 1 >= 0)
            {
                if (table[y - 1, x] == a)
                {
                    j = rpt(deleted, j, x, y - 1);
                }
            }
            if (y + 1 < table.GetLength(0))
            {
                if (table[y + 1, x] == a)
                {
                    j = rpt(deleted, j, x, y + 1);
                }
            }

            return j;

        }

        int rpt(int[,] deleted, int j, int x, int y)
        {
            int i = 0;
            while ((i < deleted.GetLength(1)) && (deleted[0, i] != x || deleted[1, i] != y))
            {
                i++;
            }
            if (i >= deleted.GetLength(1))
            {
                j++;
                deleted[0, j] = x;
                deleted[1, j] = y;
            }

            return j;
        }

        public void reWrt(int a, int b, int n, int point)
        {
            Random rnd = new Random();
            for (int i = a - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(3, 4 + i);
                for (int j = 0; j < b; j++)
                {
                    if (table[i, j] == 0)
                    {
                        int k = 1;
                        while (i - k >= 0 && table[i - k, j] == 0)
                        {
                            k++;
                        }
                        if (i - k >= 0)
                        {
                            table[i, j] = table[i - k, j];
                            table[i - k, j] = 0;
                        }
                        else
                        {
                            table[i, j] = rnd.Next(1, n);
                        }
                    }
                    color2(table[i, j]);
                    Console.Write(table[i, j] + ' ');
                }
            }

            color1(1);
            Console.SetCursorPosition(50, 1);
            Console.Write("Pontok: " + point);
        }

    }
}
