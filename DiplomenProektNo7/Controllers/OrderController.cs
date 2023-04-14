using DiplomenProektNo7.Data;
using DiplomenProektNo7.Domain;
using DiplomenProektNo7.Models.Order;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace DiplomenProektNo7.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index() 
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == userId);

            List<OrderIndexVM> orders = context 
                .Orders
                .Select(x => new OrderIndexVM
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ShoeId = x.ShoeId,
                    Shoe = x.Shoe.ShoeName,
                    Picture = x.Shoe.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,
                }).ToList();
            return View(orders);
        }
        
        public IActionResult MyOrders(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null) 
            {
                return null;
            }
            List<OrderIndexVM> orders = context
                .Orders
                .Where(x => x.UserId == user.Id)
                .Select(x => new OrderIndexVM 
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate.ToString("dd-MMM,yyyy hh:mm", CultureInfo.InvariantCulture),
                    UserId = x.UserId,
                    User = x.User.UserName,
                    ShoeId = x.ShoeId,
                    Shoe = x.Shoe.ShoeName,
                    Picture = x.Shoe.Picture,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    Discount = x.Discount,
                    TotalPrice = x.TotalPrice,
                }).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.Shoe.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return this.View(orders);
        }
        
        public ActionResult Create(int shoeId, int quantity)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
            var shoe = this.context.Shoes.SingleOrDefault(x => x.Id == shoeId);

            if (user == null || shoe == null || shoe.Quantity < quantity)
            {
                return this.RedirectToAction("Index", "Shoe");
            }
            OrderConfirmVM orderForDb = new OrderConfirmVM
            {
                UserId = userId,
                User = user.UserName,
                ShoeId = shoeId,
                ShoeName = shoe.ShoeName,
                Picture = shoe.Picture,

                Quantity = quantity,
                Price = shoe.Price,
                Discount = shoe.Discount,
                TotalPrice = quantity * shoe.Price - quantity * shoe.Price * shoe.Discount / 100
            };
            return View(orderForDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderConfirmVM bindingModel)
        {
            if (this.ModelState.IsValid) 
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
                var shoe = this.context.Shoes.SingleOrDefault(x => x.Id == bindingModel.ShoeId);

                if (user == null || shoe == null || shoe.Quantity < bindingModel.Quantity || bindingModel.Quantity == 0)
                {
                    return this.RedirectToAction("Index", "Shoe");
                }
                Order orderForDb = new Order
                {
                    OrderDate = DateTime.UtcNow,
                    ShoeId = bindingModel.ShoeId,
                    UserId = userId,
                    Quantity = bindingModel.Quantity,
                    Price = shoe.Price,
                    Discount = shoe.Discount,
                };
                shoe.Quantity -= bindingModel.Quantity;

                this.context.Shoes.Update(shoe);
                this.context.Orders.Add(orderForDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("Index", "Shoe");
        }
    }
}
