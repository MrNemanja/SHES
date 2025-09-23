using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class Clock
    {
        private int hours;
        private int minutes;
        private int seconds;
        Date date;


        public Clock()
        {
            this.hours = DateTime.Today.Hour;
            this.Minutes = DateTime.Today.Minute;
            this.Seconds = DateTime.Today.Second;
            this.Date = new Date();
        }

        public bool Tick()
        {
            this.Seconds++;
            if (this.Seconds == 60)
            {
                this.Seconds = 00;
                this.Minutes++;
            }
            if (this.Minutes == 60)
            {
                this.Minutes = 00;
                this.hours++;
            }
            if (this.hours == 24)
            {
                this.hours = 00;
                Date.DateIncrease();
                return true;
            }
            return false;
        }

        public int Hours { get { return hours; } set { hours = value; } }
        public int Minutes { get => minutes; set => minutes = value; }
        public int Seconds { get => seconds; set => seconds = value; }
        public Date Date { get => date; set => date = value; }
    }
}
