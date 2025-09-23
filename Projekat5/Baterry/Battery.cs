using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baterry
{
    public class Battery: IBattery
    {
        private int id;
        private int maxSnaga;
        private int kapacitet;

        public Battery() { }

        public Battery(int id, int max, int cap)
        {
            this.id = id;
            this.maxSnaga = max;
            this.kapacitet = cap;
        }

        public int Id { get => id; set => id = value; }
        public int MaxSnaga { get => maxSnaga; set => maxSnaga = value; }
        public int Kapacitet { get => kapacitet; set => kapacitet = value; }

    }
}
