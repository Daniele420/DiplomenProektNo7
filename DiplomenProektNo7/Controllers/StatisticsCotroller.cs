using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Models.Statistics;
using Microsoft.AspNetCore.Authorization;

namespace DiplomenProektNo7.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        { this.statisticsService = statisticsService; }
        public IActionResult Index()
        {
            StatisticsVM statistics = new StatisticsVM();
            statistics.CountClients = statisticsService.CountClients();
            statistics.CountShoes = statisticsService.CountShoes();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = (int)statisticsService.SumOrders();

            return View(statistics);
        }
    }
}