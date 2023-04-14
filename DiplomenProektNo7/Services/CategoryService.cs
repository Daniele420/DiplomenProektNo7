using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Data;
using DiplomenProektNo7.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DiplomenProektNo7.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }
        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public List<Shoe> GetShoesByCategory(int categoryId)
        {
            return _context.Shoes
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }
    }
}
