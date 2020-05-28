using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Departament Departament { get; set; }
        public ICollection<SallesRecord> Sales { get; set; } = new List<SallesRecord>();
    

        public Seller()
        {

        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Departament departament)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Departament = departament;
        }


        public void AddSales(SallesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SallesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
