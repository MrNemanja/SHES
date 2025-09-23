using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baterry
{
    public interface IBattery
    {
       int Id{ get; set; }

       int MaxSnaga{ get; set; }

       int Kapacitet{ get; set; }
    }
}
