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

            Rekords r = new Rekords(Rekords.Num());
            r.Current();

            Console.Write("Szeretné megnézni az eddigi rekordokat? (I/N): ");
            WriteRecords(Console.ReadLine(), r, 0);

            Console.Write("Nev: ");
            string name = Console.ReadLine().Replace(" ","_");
            Console.Write("Mennyi ideig szeretne jatszani (*60 mp): ");
            double time = 60 * double.Parse(Console.ReadLine());
            Console.WriteLine();

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            Table table = new Table(a, b, n);
            table.wrt();

            stopwatch.Start();

            int[] xy;
            int point = 0;

            while (stopwatch.ElapsedMilliseconds / 1000 < time)
            {
                xy = table.chng();
                point = point + table.pnt(xy[0], xy[1]);
                point = point + table.pnt(xy[2], xy[3]);
                table.wrt();
                table.reWrt(a, b, n, point);
            }

            table.Clr(b + 3, 2);
            table.Clr(0, 4);
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Vége");
            Console.WriteLine("Összegyűjtött pontok: " + point);

            System.Threading.Thread.Sleep(775);
            Player gamer = new Player(name, time, point);
            r.AddNew(gamer);
            WriteRecords("I", r, 1);

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
    }
}