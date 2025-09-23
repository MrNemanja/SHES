using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility 
{
    public class Utility : IUtility
    {
        private int cena;

        public Utility() { }

        public Utility(int cena)
        {
            this.cena = cena;
        }

        public int Cena { get { return cena; } set { cena = value; }  }

        public double Naplata(int snaga)
        {
            return snaga * this.cena / 3600.0f;
        }
    }
}
