using DiplomenProektNo7.Data;
using DiplomenProektNo7.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Abstraction
{
    public class ShoeService : IShoeService
    {
        private readonly ApplicationDbContext _context;

        public ShoeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount, string description, string colour, string material)
        {
            Shoe item = new Shoe
            {
                ShoeName = name,
                Brand = _context.Brands.Find(brandId),
                Category = _context.Categories.Find(categoryId),

                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount,
                Description = description,
                Colour = colour,
                Material = material
            };

            _context.Shoes.Add(item);
            return _context.SaveChanges() != 0;
        }
        public Shoe GetShoeById(int shoeId)
        {
            return _context.Shoes.Find(shoeId);
        }
        public List<Shoe> GetShoes()
        {
            List<Shoe> shoes = _context.Shoes.ToList();
            return shoes;
        }

        public bool RemoveById(int shoeId)
        {
            var shoe = GetShoeById(shoeId);
            if (shoe == default(Shoe))
            {
                return false;
            }
            _context.Remove(shoe);
            return _context.SaveChanges() != 0;
        }
        public List<Shoe> GetShoes(string searchStringCategoryName, string searchStringBrandName)
        {
            List<Shoe> shoes = _context.Shoes.ToList();
            if (!String.IsNullOrEmpty(searchStringCategoryName) && !String.IsNullOrEmpty(searchStringBrandName))
            {
                shoes = shoes.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())
                && x.Brand.BrandName.ToLower().Contains(searchStringBrandName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringCategoryName))
            {
                shoes = shoes.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringBrandName))
            {
                shoes = shoes.Where(x => x.Brand.BrandName.ToLower().Contains(searchStringBrandName.ToLower())).ToList();
            }
            return shoes;
        }
        public bool Update(int shoeId, string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount, string description, string colour, string material)
        {
            var shoe = GetShoeById(shoeId);
            if (shoe == default(Shoe))
            {
                return false;
            }
            shoe.ShoeName = name;

            shoe.Brand = _context.Brands.Find(brandId);
            shoe.Category = _context.Categories.Find(categoryId);

            shoe.Picture = picture;
            shoe.Quantity = quantity;
            shoe.Price = price;
            shoe.Discount = discount;
            shoe.Description = description;
            shoe.Colour = colour;
            shoe.Material = material;
            _context.Update(shoe);
            return _context.SaveChanges() != 0;
        }
    }
}