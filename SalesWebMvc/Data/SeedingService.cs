﻿using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using SalesWebMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");

            Seller s1 = new Seller(1, "juan@gmail.com", "Juan", new DateTime(1998, 4, 21), 1000.0, d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2);
            _context.Seller.Add(s1);
            _context.SalesRecord.Add(sr1);

            _context.SaveChanges();
        }
    }
}