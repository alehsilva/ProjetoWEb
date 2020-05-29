using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departament.Any() ||
                _context.Seller.Any() ||
                _context.SallesRecords.Any())
            {
                return; // Banco has been seeded.
            }

            Departament d1 = new Departament(1, "Computers");
            Departament d2 = new Departament(2, "Electronics");

            Seller s1 = new Seller(1, "Alexandre", "Alehsilva@live.com", 1000.00, new DateTime(1998, 12, 03), d1);
            Seller s2 = new Seller(2, "Amanda", "amanda@live.com", 2000.00, new DateTime(1998, 12, 03), d2);

            SallesRecord r1 = new SallesRecord(1, new DateTime(2018, 09, 25), 1000.00, SaleStatus.Billed, s1);
            SallesRecord r2 = new SallesRecord(2, new DateTime(2015, 09, 25), 1000.00, SaleStatus.Billed, s2);
            SallesRecord r3 = new SallesRecord(3, new DateTime(2019, 09, 25), 1000.00, SaleStatus.Billed, s1);

            _context.Departament.AddRange(d1, d2);
            _context.Seller.AddRange(s1, s2);
            _context.SallesRecords.AddRange(r1, r2, r3);

            _context.SaveChanges();
        }
    }
}
