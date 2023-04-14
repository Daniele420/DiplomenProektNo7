using DiplomenProektNo7.Data;
using DiplomenProektNo7.Models.ContactUs;
using DiplomenProektNo7.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiplomenProektNo7.Domain;

namespace DiplomenProektNo7.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            // Get all messages from the database
            List<MessageIndexVm> messages = new List<MessageIndexVm>();

            // Pass the list of messages to the view
            return View();
        }
        public async Task<IActionResult> MessageList()
        {
            IQueryable<Message> messages = _context.Messages;

            var messageVMs = await messages.OrderByDescending(m => m.DateSent)
                .Select(m => new MessageIndexVm
                {
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    Comment = m.Comment
                })
                .ToListAsync();

            return View(messageVMs);
        }
    }
}
