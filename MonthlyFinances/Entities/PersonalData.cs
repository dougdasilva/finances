using MonthlyFinances.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyFinances.Entities
{
    class PersonalData
    {
        public string Name { get; set; }
        public string Competence { get; set; }
        public double BaseSalary { get; set; }
        public Workspace Worker { get; set; }
        public Performance Performance { get; set; }
        public List<ExtraIncome> Extras { get; set; } = new List<ExtraIncome>();
        public List<BillsToPay> Bills { get; set; } = new List<BillsToPay>();

        public PersonalData()
        {

        }

        public PersonalData(string name, string competence, double baseSalary, Workspace worker, Performance performance)
        {
            Name = name;
            Competence = competence;
            BaseSalary = baseSalary;
            Worker = worker;
            Performance = performance;
        }
        public void AddExtra(ExtraIncome extraIncome)
        {
            Extras.Add(extraIncome);
        }
        public void AddBillsToPay(BillsToPay toPay)
        {
            Bills.Add(toPay);
        }
        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (ExtraIncome extra in Extras)
            {
                if(extra.DateExtra.Year == year && extra.DateExtra.Month == month)
                {
                    sum += extra.TotalExtra();
                }
            }
            return sum;
        }
        public double ToPay(int year, int month)
        {
            double sub = 0.0;
            foreach (BillsToPay b in Bills)
            {
                if(b.PayDay.Year == year && b.PayDay.Month == month)
                {
                    sub += b.TotalPay();
                }
            }
            return sub;
        }
       
    }
}
