using System;
using FinanceBackEnd.Models.Enums;

namespace FinanceBackEnd.Models.Model {
    public class TransactionStock {

        public int Id {get; set;}

        public DateTime Date {get; set;}

        public int IdStock {get; set;}        

        public double Quantity {get; set;}

        public double UnitPrice {get; set;}

        public double Cost {get; set;}

        public TransactionType Type {get; set;}
    }
}