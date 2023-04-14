using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Data;
using DiplomenProektNo7.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DiplomenProektNo7.Abstraction
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand GetBrandById(int brandId);
        List<Shoe> GetShoesByBrand(int brandId);
    }
}