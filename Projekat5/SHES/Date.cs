using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            this.Day = DateTime.Today.Day;
            this.Month = DateTime.Today.Month;
            this.Year = DateTime.Today.Year;
        }
        public Date(int d, int m, int y)
        {
            this.Day = d;
            this.Month = m;
            this.Year = y;
        }

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }

        public void DateIncrease()
        {
            this.Day++;
            if (this.Month == 1 || this.Month == 3 || this.Month == 5 || this.Month == 7 || this.Month == 8 || this.Month == 10 || this.Month == 12)
            {
                if (this.Day == 32)
                {
                    this.Day = 1;
                    this.Month++;
                }
            }
            else if (this.Month == 2)
            {
                if (this.Year % 4 == 0)
                {
                    if (this.Day == 30)
                    {
                        this.Day = 1;
                        this.Month++;
                    }
                }
                else
                {
                    if (this.Day == 29)
                    {
                        this.Day = 1;
                        this.Month++;
                    }
                }
            }
            else
            {
                if (this.Day == 31)
                {
                    this.Day = 1;
                    this.Month++;
                }
            }


            if (this.Month == 13)
            {
                this.Month = 1;
                this.Year++;
            }
            
        }
    }
}
