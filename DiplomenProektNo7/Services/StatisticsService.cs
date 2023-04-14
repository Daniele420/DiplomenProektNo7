using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Data;

namespace DiplomenProektNo7.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public int CountClients()
        {

            return _context.Users.Count() - 1;
        }

        public int CountOrders()
        {
            return _context.Orders.Count();
        }

        public int CountShoes()
        {
            return _context.Shoes.Count();
        }

        public decimal SumOrders()
        {
            return _context.Orders.Sum(x => x.Quantity * x.Price - x.Quantity * x.Price * x.Discount / 100);
        }
    }
}
