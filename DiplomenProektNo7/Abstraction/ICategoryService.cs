using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Data;
using DiplomenProektNo7.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DiplomenProektNo7.Abstraction
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Shoe> GetShoesByCategory(int categoryId);
    }
}