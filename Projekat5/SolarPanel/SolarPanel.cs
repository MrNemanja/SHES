using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanel
{
    public class SolarPanel: ISolarPanel
    {
        private int id;
        private int maxSnaga;

        public SolarPanel() { }

        public SolarPanel(int id, int max)
        {
            this.id = id;
            this.maxSnaga = max;
        }

        public int Id 
        { 
            get { return id; }
            set { id = value; }
        }

        public int Max_snaga { get { return maxSnaga; } set { maxSnaga = value; } }

        //public int TrenutnaSnaga { get => trenutnaSnaga; set => trenutnaSnaga = value; }

        public int primi(int trenutnaSnagaProc)
        {
            return maxSnaga * (trenutnaSnagaProc / 100);
        }

    }
}
