using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class Podaci
    {
        private int energija_baterije;
        private double energija_distribucije;
        private int energija_panela;
        private int potrosnja_potrosaca;

        public Podaci() {}
        public Podaci(int bat, double dist, int pan, int pot)
        {
            this.energija_baterije = bat;
            this.energija_distribucije = dist;
            this.energija_panela = pan;
            this.potrosnja_potrosaca = pot;
        }

        public int Energija_baterije { get => energija_baterije; set => energija_baterije = value; }
        public double Energija_distribucije { get => energija_distribucije; set => energija_distribucije = value; }
        public int Energija_panela { get => energija_panela; set => energija_panela = value; }
        public int Potrosnja_potrosaca { get => potrosnja_potrosaca; set => potrosnja_potrosaca = value; }
    }
}
