using DiplomenProektNo7.Domain;
using DiplomenProektNo7.Models;
using DiplomenProektNo7.Models.ContactUs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DiplomenProektNo7.Data;

namespace DiplomenProektNo7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUsResult()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> ContactUs(ContactViewModel model)
        {
            if (model.Comment == null)
            {
                ModelState.AddModelError("Comment", "The comment field is required.");
                return View(model);
            }

            // Map the view model to a message model
            var message = new Message
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Comment = model.Comment,
                DateSent = DateTime.UtcNow
            };

            // Save the message to the database
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            // Redirect to the home page with a success message
            TempData["Message"] = "Your message has been sent successfully.";
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}