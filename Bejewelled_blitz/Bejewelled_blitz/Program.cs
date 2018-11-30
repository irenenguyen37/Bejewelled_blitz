using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejewelled_blitz
{
    class Program
    {

        static void Main(string[] args)
        {
            Settings.sttngs();
            int a = Settings.y();
            int b = Settings.x();
            int n = Settings.colors();

            do
            {
                Rekords r = new Rekords(Rekords.Num());
                r.Current();

                Console.Write("Szeretné megnézni az eddigi rekordokat? (I/N): ");
                WriteRecords(Console.ReadLine(), r, 0);

                Console.Write("Nev: ");
                string name = Console.ReadLine().Replace(" ", "_");
                Console.Write("Mennyi ideig szeretne jatszani (*60 mp): ");
                double time = 60 * double.Parse(Console.ReadLine());
                Console.WriteLine();

                System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

                Table table = new Table(a, b, n);
                table.wrt();

                stopwatch.Start();

                int[] xy;

                while (stopwatch.ElapsedMilliseconds / 1000 < time)
                {
                    xy = table.chng();
                    stopwatch.Stop();
                    table.pnt(xy[0], xy[1]);
                    table.pnt(xy[2], xy[3]);
                    table.wrt();
                    table.reWrt(a, b, n);
                    stopwatch.Start();

                    Console.SetCursorPosition(50, 1);
                    Console.Write("Pontok: " + table.Point);
                }

                table.Clr(b + 3, 2);
                table.Clr(0, 4);
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Vége");
                Console.WriteLine("Összegyűjtött pontok: " + table.Point);

                System.Threading.Thread.Sleep(775);
                Player gamer = new Player(name, time, table.Point);
                r.AddNew(gamer);
                WriteRecords("I", r, 1);

                Console.Write("Új játék?: ");
            } while (Console.ReadLine().ToUpper() == "I");

            end();

        }
        
        static void WriteRecords(string a, Rekords r, int b)
        {
            if (a.ToUpper() == "I")
            {
                Console.Clear();
                r.Show(b);
            }
            Console.Clear();
        }

        static void end()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            string a = "További szép napot!";
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                System.Threading.Thread.Sleep(100);

            }
            System.Threading.Thread.Sleep(1000);
        }
    }
}