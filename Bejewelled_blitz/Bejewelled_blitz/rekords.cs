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
        int newIndex;

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
            return n+1;
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
            rekords[rekords.Length-1] = new Player();
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
                    if (i == newIndex)
                        {   Table.color1(2); }
                    else
                        { Table.color1(1); }

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
                newIndex = 0;
            }
            else
            {
                int i = 0;
                while (i < rekords.Length && rekords[i].Time >= a.Time && rekords[i].Points >= a.Points)
                {
                    i++;
                }
                for (int j = rekords.Length-1; j > i; j--)
                {
                    rekords[j] = rekords[j-1];
                }
                rekords[i] = a;
                newIndex =  i;
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
