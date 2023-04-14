using DiplomenProektNo7.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DiplomenProektNo7.Models.Shoe;
using DiplomenProektNo7.Models.Order;
using DiplomenProektNo7.Models.Client;
using DiplomenProektNo7.Models.Statistics;
using DiplomenProektNo7.Models.ContactUs;

namespace DiplomenProektNo7.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeCreateVM> ShoeCreateVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeIndexVM> ShoeIndexVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeEditVM> ShoeEditVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeDetailsVM> ShoeDetailsVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Shoe.ShoeDeleteVM> ShoeDeleteVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Order.OrderConfirmVM> OrderConfirmVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Order.OrderIndexVM> OrderIndexVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Client.ClientIndexVM> ClientIndexVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Client.ClientDeleteVM> ClientDeleteVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.Statistics.StatisticsVM> StatisticsVM { get; set; }
        public DbSet<DiplomenProektNo7.Models.ContactUs.ContactViewModel> ContactViewModel { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
