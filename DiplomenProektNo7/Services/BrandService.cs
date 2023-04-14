using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Data;
using DiplomenProektNo7.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DiplomenProektNo7.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;

        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Brand GetBrandById(int brandId)
        {
            return _context.Brands.Find(brandId);
        }
        public List<Brand> GetBrands()
        {
            List<Brand> brands = _context.Brands.ToList();
            return brands;
        }
        public List<Shoe> GetShoesByBrand(int brandId) 
        {
            return _context.Shoes
                .Where(x => x.BrandId == brandId)
                .ToList();
        }
    }
}
