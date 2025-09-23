using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanel
{
    public interface ISolarPanel
    {
        int primi(int trenutnaSnagaProc);

        int Id{ get; set; }

        int Max_snaga{ get; set; }
    }
}
