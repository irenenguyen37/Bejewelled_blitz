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

        Player[] rekords;

        /*
        string name;
        double time;
        int points;
        */
        #region Default
        /*
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
        */
        #endregion


        public Rekords(int num)
        {
            rekords = new Player[num];
        }


        public static int Num()
        {
            int n;
            StreamReader sr = new StreamReader("rekords.txt", Encoding.Default);
            n = int.Parse(sr.ReadLine());
            sr.Close();
            return n;
        }
        public void Current()
        {
            int n;
            StreamReader sr = new StreamReader("rekords.txt", Encoding.Default);
            n = int.Parse(sr.ReadLine());

            string[] lines = new string[n];

            for (int i = 0; i < n; i++)
            {
                lines[i] = sr.ReadLine();
                string[] person = lines[i].Split();
                rekords[i] = new Player(person[0],double.Parse(person[1]), int.Parse(person[2]));
            }
            sr.Close();
        }

        public void Show(int a)
        {
            Console.WriteLine("Rekordok:");
            Console.WriteLine();
            if (a == 0)
            {
                for (int i = 0; i < rekords.Length-1; i++)
                {
                    Console.Write(rekords[i].Name);
                    Console.SetCursorPosition(20, i + 2);
                    Console.WriteLine(rekords[i].Time + " mp");
                    Console.SetCursorPosition(35, i + 2);
                    Console.WriteLine(rekords[i].Points + " pont");
                }
            }
            else
            {
                for (int i = 0; i < rekords.Length; i++)
                {
                    Console.Write(rekords[i].Name);
                    Console.SetCursorPosition(20, i + 2);
                    Console.WriteLine(rekords[i].Time + " mp");
                    Console.SetCursorPosition(35, i + 2);
                    Console.WriteLine(rekords[i].Points + " pont");
                }
                Save();
            }

            Console.ReadLine();
        }

        public void AddNew(Player a)
        {
            if (rekords.Length == 1)
            {
                rekords[0] = a;
            }
            else
            {
                int i = 0;
                while (i < rekords.Length && rekords[i].Time > a.Time)
                {
                    i++;
                }
                for (int j = rekords.Length-1; j > i; j--)
                {
                    rekords[j] = rekords[j-1];
                }
                rekords[i] = a;
            }
        }

        private void Save()
        {
            StreamWriter sw = new StreamWriter("rekords.txt");
            sw.WriteLine(rekords.Length);
            for (int i = 0; i < rekords.Length; i++)
            {
                sw.WriteLine(rekords[i].Name + " " + rekords[i].Time + " " + rekords[i].Points);
            }
            sw.Close();

        }
    }
}
