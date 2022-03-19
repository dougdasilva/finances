using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyFinances.Entities
{
    class ExtraIncome
    {
        public DateTime DateExtra { get; set; }
        public double ValuePerHours { get; set; }
        public int Hours { get; set; }

        public ExtraIncome()
        {
        }

        public ExtraIncome(DateTime dateExtra, double valuePerHours, int hours)
        {
            DateExtra = dateExtra;
            ValuePerHours = valuePerHours;
            Hours = hours;
        }

        public double TotalExtra()
        {
            return Hours * ValuePerHours;
        }
    }
}
