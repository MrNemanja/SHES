using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potrosaci
{
    public interface IPotrosaci
    {
       string Ime{ get; set; }

       int Potrosnja { get; set; }

       bool Stanje { get; set; }
    }
}
