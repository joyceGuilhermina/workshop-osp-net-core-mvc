using ProjetoWebMvc.Models.Enums;
using System;


namespace ProjetoWebMvc.Models
{
    public class SalesRecord
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public int MyProperty { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, int myProperty, SaleStatus status, Seller seller)
        {
            this.id = id;
            Date = date;
            Amount = amount;
            MyProperty = myProperty;
            Status = status;
            Seller = seller;
        }
    }
}
