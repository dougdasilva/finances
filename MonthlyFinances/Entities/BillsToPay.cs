using System;

namespace MonthlyFinances.Entities
{
    class BillsToPay
    {
        public string TypeOfTicket { get; set; }
        public DateTime PayDay { get; set; }
        public double TicketValue { get; set; }

        public BillsToPay()
        {
        }

        public BillsToPay(string typeOfTicket, DateTime payDay, double bill)
        {
            TypeOfTicket = typeOfTicket;
            PayDay = payDay;
            TicketValue = bill;
        }

        public virtual double TotalPay()
        {
            return TicketValue;
        }
    }
}
