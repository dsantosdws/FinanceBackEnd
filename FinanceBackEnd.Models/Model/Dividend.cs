using System;
using FinanceBackEnd.Models.Enums;

namespace FinanceBackEnd.Models.Model {
    
    public class Dividend {

        public int Id {get; set;}

        public int IdStock {get; set;}

        public Stock Stock {get; set;}

        public DateTime Date {get; set;}

        public int Quantity {get; set;}

        public double Amount {get; set;}

        public DividendType Type {get; set;}
    }
}