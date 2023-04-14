using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Abstraction
{
    public interface IStatisticsService
    {
        int CountShoes();
        int CountClients();
        int CountOrders();
        decimal SumOrders();
    }
}
