using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bejewelled_blitz
{
    public class Player
    {

        string name;
        double time;
        int points;

        #region Default
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Time
        {
            get { return time; }
            set { time = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public Player(string n, double t, int p)
        {
            this.name = n;
            this.time = t;
            this.points = p;
        }

        public Player()
        {
            this.name = "";
            this.time = 0;
            this.points = 0;
        }
 
        #endregion
    }
}
