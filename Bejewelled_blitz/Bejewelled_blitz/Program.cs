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

                Table table = new Table();
                table.Wrt();

                stopwatch.Start();

                while (stopwatch.ElapsedMilliseconds / 1000 < time)
                {
                    table.Chng();
                    table.ReWrt();

                    Console.SetCursorPosition(50, 1);
                    Console.Write("Pontok: " + table.Point);
                }

                table.Clr(Settings.xTg + 3, 2);
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
            Console.Clear();
            if (a.ToUpper() == "I")
            {
                r.Show(b);
            }
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
            System.Threading.Thread.Sleep(750);
        }
    }
}