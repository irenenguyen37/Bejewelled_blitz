using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejewelled_blitz
{
    public class Rekords
    {
        string name;
        double time;
        int points;

        #region Default
        public string Name
        {
            get { return name; }
        }

        public double Time
        {
            get { return time; }
        }

        public int Points
        {
            set { points = value; }
            get { return points; }
        }

        public Rekords(string n, double t)
        {
            this.name = n;
            this.time = t;
            this.points = 0;
        }

        public Rekords(string n, double t, int p)
        {
            this.name = n;
            this.time = t;
            this.points = p;
        }

        public Rekords()
        {
            this.name = "";
            this.time = 0;
            this.points = 0;
        }

        #endregion

        public static Rekords[] Current()
        {
            int n;
            StreamReader sr = new StreamReader("rekords.txt", Encoding.Default);
            n = int.Parse(sr.ReadLine());

            Rekords[] rekord = new Rekords[n + 1];
            string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = sr.ReadLine();
                string[] person = lines[i].Split();
                rekord[i] = new Rekords(person[0],double.Parse(person[1]), int.Parse(person[2]));
                //rekord[i].name = person[0];
                //rekord[i].time = double.Parse(person[1]);
                //rekord[i].points = int.Parse(person[2]);
            }

            sr.Close();
            return rekord;
        }

        public static void Show(Rekords[] r, int a)
        {
            Console.WriteLine("Rekordok:");
            if (a == 0)
            {
                for (int i = 0; i < r.Length-1; i++)
                {
                    Console.WriteLine(r[i].name + "\t\t" + r[i].time + "mp\t\t" + r[i].points + " pont");
                }
            }
            else
            {
                for (int i = 0; i < r.Length; i++)
                {
                    Console.WriteLine(r[i].name + "\t\t" + r[i].time + "mp\t\t" + r[i].points + " pont");

                }
                Save(r);
            }

            Console.ReadLine();
        }

        public static void AddNew(Rekords[] r, Rekords a)
        {
            if (r.Length == 1)
            {
                r[0] = a;
            }
            else
            {
                int i = 0;
                while (i < r.Length && r[i].time > a.time)
                {
                    i++;
                }
                for (int j = r.Length-1; j > i; j--)
                {
                    r[j] = r[j-1];
                }
                r[i] = a;
            }
        }

        private static void Save(Rekords[] r)
        {
            StreamWriter sw = new StreamWriter("rekords.txt");
            sw.WriteLine(r.Length);
            for (int i = 0; i < r.Length; i++)
            {
                sw.WriteLine(r[i].name + " " + r[i].time + " " + r[i].points);
            }
            sw.Close();

        }
    }
}
