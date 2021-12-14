using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MyProperty { get; set; }
        public DateTime Birthdate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> sales { get; set; } = new List<SalesRecord>();


        public Seller()
        {
        }

        public Seller(int id, string name, string email, int myProperty, DateTime birthdate, double baseSalary, Department department)
        {
            this.id = id;
            Name = name;
            Email = email;
            MyProperty = myProperty;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            sales.Remove(sr);
        }
        
        public double TotalSales(DateTime initial, DateTime final)
        {
            return sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
