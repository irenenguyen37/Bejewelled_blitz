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
        int point;
        private int[] changed;

        public int Point
        {
            get { return point; }
        }

        public Table()
        {
            Random r = new Random();
            this.table = new int[Settings.yTg, Settings.xTg];
            this.point = 0;

            for (int i = 0; i < Settings.yTg; i++)
            {
                for (int j = 0; j < Settings.xTg; j++)
                {
                   table[i, j] = r.Next(1, Settings.Color + 1);
                }
            }
        }

        public void Wrt()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("   ");

            int a = 1;
            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (a < 10)
                {
                    Settings.Color1(a);
                    Console.Write(a + " ");
                }
                else
                {
                    Settings.Color1(a);
                    Console.Write(a);
                }
                a++;
            }
            Console.WriteLine();

            a = 1;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                Settings.Color1(a);
                if (a < 10)
                    Console.Write(a + " ");
                else
                    Console.Write(a);
                Settings.Color1(1);
                Console.Write(" ");

                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Settings.Color2(table[i, j]);
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine();
                a++;
            }
            Settings.Color1(1);
            Console.WriteLine();
        }
        public void ReWrt()
        {
            Random rnd = new Random();
            for (int i = Settings.yTg - 1; i >= 0; i--)
            {
                Console.SetCursorPosition(3, 4 + i);
                for (int j = 0; j < Settings.xTg; j++)
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
                            table[i, j] = rnd.Next(1, Settings.Color + 1);
                        }
                    }
                    Settings.Color2(table[i, j]);
                    Console.Write(table[i, j] + ' ');
                }
            }
            Settings.Color1(1);
        }

        private void CellWrt(int x, int y, int c)
        {
            Console.SetCursorPosition(x * 2 + 3, y + 4);
            Settings.Color2(c);
            Console.Write(table[y, x] + " ");
            //System.Threading.Thread.Sleep(1000);
        }

        #region swap
        public void Chng()
        {
            changed = new int[4];
            int a = table.GetLength(0) - 1;
            int b = table.GetLength(1) - 1;
            Console.SetCursorPosition(0, a + 6);
            int clrS = 1;

            Console.WriteLine("Melyik két elemet szeretnéd felcserélni?");
            do
            {
                Console.Write("x1 (1-79): ");
                changed[0] = int.Parse(Console.ReadLine()) - 1;
                clrS++;
            } while (changed[0] > b || changed[0] < 0);
            do
            {
                Console.Write("y1 (1-24): ");
                changed[1] = int.Parse(Console.ReadLine()) - 1;
                clrS++;
            } while (changed[1] > a || changed[1] < 0);

            string d;
            do
            {
                Console.Write("Melyik irányba mozgassa? (w/a/s/d): ");
                d = Console.ReadLine();
                changed[2] = changed[0] + Drctn(d)[0];
                changed[3] = changed[1] + Drctn(d)[1];
                clrS++;
            } while (changed[2] > b || changed[2] < 0 || changed[3] > a || changed[3] < 0 || Math.Abs(changed[0] - changed[2]) + Math.Abs(changed[1] - changed[3]) > 1 || !(d == "w" || d == "a" || d == "s" || d == "d"));

            Clr(a + 6, clrS);

            int s = table[changed[1], changed[0]];
            table[changed[1], changed[0]] = table[changed[3], changed[2]];
            table[changed[3], changed[2]] = s;

            CellWrt(changed[0], changed[1], table[changed[1], changed[0]]);
            CellWrt(changed[2], changed[3], table[changed[3], changed[2]]);

            Settings.Color1(1);

            Pnt(changed[0], changed[1]);
            if (table[changed[3], changed[2]] != 0)
            {
                Pnt(changed[2], changed[3]);
            }
        }

        private int[] Drctn(string d)
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
        #endregion

        #region points
        private void Pnt(int x, int y)
        {
            int[,] deleted = new int[2, table.GetLength(0) * table.GetLength(1)];
            int i = 0;
            int j = 0;
            deleted[0, i] = x;
            deleted[1, i] = y;

            int a = table[y, x];
            do
            {
                x = deleted[0, i];
                y = deleted[1, i];
                table[y, x] = 0;
                CellWrt(x, y, 0);

                if (x - 1 >= 0)
                {
                    if (table[y, x - 1] == a)
                    {
                        j = Rpt(deleted, j, x - 1, y);
                    }
                }
                if (x + 1 < table.GetLength(1))
                {
                    if (table[y, x + 1] == a)
                    {
                        j = Rpt(deleted, j, x + 1, y);
                    }
                }
                if (y - 1 >= 0)
                {
                    if (table[y - 1, x] == a)
                    {
                        j = Rpt(deleted, j, x, y - 1);
                    }
                }
                if (y + 1 < table.GetLength(0))
                {
                    if (table[y + 1, x] == a)
                    {
                        j = Rpt(deleted, j, x, y + 1);
                    }
                }
                i++;

            } while (i < j + 1);

            if (j == 0)
            {
                table[y, x] = a;
                point = point + j;
                CellWrt(x, y, a);
            }
            else
            {
                point = point + j + 1;
            }
        }

        private int Rpt(int[,] deleted, int j, int x, int y)
        {
            int i = 0;
            while ((i < deleted.GetLength(1)) && (deleted[0, i] != x || deleted[1, i] != y))
            {
                i++;
            }

            if ((y == 0 && x == 0) )
            {
                j++;
            }

            if (i >= deleted.GetLength(1))
            {
                j++;
                deleted[0, j] = x;
                deleted[1, j] = y;
            }

            return j;
        }
        #endregion
    }
}
