using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Models.Statistics
{
    public class StatisticsVM
    {
        [Key]
        [Display(Name = "Count Clients")]
        public int CountClients { get; set; }
        [Display(Name = "Count Shoes")]
        public int CountShoes { get; set; }
        [Display(Name = "Count Orders")]
        public int CountOrders { get; set; }
        [Display(Name = "Total Sum Orders")]
        public decimal SumOrders { get; set; }
    }
}
