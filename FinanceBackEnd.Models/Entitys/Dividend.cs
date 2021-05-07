using System;

namespace FinanceBackEnd.Models.Entitys
{
    public class Dividend : BaseEntity
    {
        public int IdStock { get; set; }

        public DateTime Date { get; set; }

        public int Type { get; set; }

        public int Quantity { get; set; }

        public double Amount { get; set; }
    }
}