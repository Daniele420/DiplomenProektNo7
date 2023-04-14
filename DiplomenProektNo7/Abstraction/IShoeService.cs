using DiplomenProektNo7.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Abstraction
{
    public interface IShoeService
    {
        bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount, string description, string colour, string material);
        bool Update(int shoeId, string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount, string description, string colour, string material);
        List<Shoe> GetShoes();
        Shoe GetShoeById(int shoeId);
        bool RemoveById(int sportshoeId);
        List<Shoe> GetShoes(string searchStringCategoryName, string searchStringBrandName);
    }
}
