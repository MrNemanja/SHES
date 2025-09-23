using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potrosaci
{
    public class Potrosaci: IPotrosaci
    {
        private string ime;
        private int potrosnja;
        private bool stanje;

        public Potrosaci() { }

        public Potrosaci(string ime, int potrosnja, bool stanje)
        {
            this.ime = ime;
            this.potrosnja = potrosnja;
            this.stanje = stanje;
        }

        public int Potrosnja
        {
            get { return potrosnja; }
            set { potrosnja = value; }
        }
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        public bool Stanje
        {
            get { return stanje; }
            set { stanje = value; }
        }
    }
}
