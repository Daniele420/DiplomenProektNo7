using DiplomenProektNo7.Abstraction;
using DiplomenProektNo7.Domain;
using DiplomenProektNo7.Models.Brand;
using DiplomenProektNo7.Models.Category;
using DiplomenProektNo7.Models.Shoe;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DiplomenProektNo7.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ShoeController : Controller
    {
        private readonly IShoeService _shoeService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ShoeController(IShoeService shoeService, ICategoryService categoryService, IBrandService brandService)
        {
            this._shoeService = shoeService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }
        public ActionResult Create()
        {
            var shoe = new ShoeCreateVM();
            shoe.Brands = _brandService.GetBrands()
                .Select(x => new BrandPairVM()
                {
                    Id = x.Id,
                    Name = x.BrandName
                }).ToList();
            shoe.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryPairVM()
                {
                    Id = x.Id,
                    Name = x.CategoryName
                }).ToList();
            return View(shoe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ShoeCreateVM shoe)
        {
            if (ModelState.IsValid)
            {
                var createId = _shoeService.Create(shoe.ShoeName, shoe.BrandId,
                                                   shoe.CategoryId, shoe.Picture,
                                                   shoe.Quantity, shoe.Price, shoe.Discount,
                                                   shoe.Description, shoe.Colour, shoe.Material);
                if (createId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringBrandName)
        {
            List<ShoeIndexVM> shoes = _shoeService.GetShoes(searchStringCategoryName, searchStringBrandName)
                .Select(shoe => new ShoeIndexVM
                {
                    Id = shoe.Id,
                    ShoeName = shoe.ShoeName,
                    BrandId = shoe.BrandId,
                    BrandName = shoe.Brand.BrandName,
                    CategoryId = shoe.CategoryId,
                    CategoryName = shoe.Category.CategoryName,
                    Picture = shoe.Picture,
                    Quantity = shoe.Quantity,
                    Price = shoe.Price,
                    Discount = shoe.Discount,
                    Description = shoe.Description,
                    Colour = shoe.Colour,
                    Material = shoe.Material

                }).ToList();
            return this.View(shoes);
        }
        public ActionResult Edit(int id)
        {
            Shoe shoe = _shoeService.GetShoeById(id);
            if (shoe == null)
            {
                return NotFound();
            }

            ShoeEditVM updatedShoe = new ShoeEditVM()
            {

                Id = shoe.Id,
                ShoeName = shoe.ShoeName,
                BrandId = shoe.BrandId,
                CategoryId = shoe.CategoryId,
                Picture = shoe.Picture,
                Quantity = shoe.Quantity,
                Price = shoe.Price,
                Discount = shoe.Discount,
                Description = shoe.Description,
                Colour = shoe.Colour,
                Material = shoe.Material
            };
            updatedShoe.Brands = _brandService.GetBrands()
                .Select(b => new BrandPairVM()
                {
                    Id = b.Id,
                    Name = b.BrandName
                })
                .ToList();

            updatedShoe.Categories = _categoryService.GetCategories()
                .Select(c => new CategoryPairVM()
                {
                    Id = c.Id,
                    Name = c.CategoryName
                })
                .ToList();
            return View(updatedShoe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShoeEditVM shoe)
        {
            {
                if (ModelState.IsValid)
                {
                    var updated = _shoeService.Update(id, shoe.ShoeName, shoe.BrandId,
                                                     shoe.CategoryId, shoe.Picture,
                                                     shoe.Quantity, shoe.Price, shoe.Discount,
                                                     shoe.Description, shoe.Colour, shoe.Material);
                    if (updated)
                    {
                        return this.RedirectToAction("Index");
                    }
                }
                return View(shoe);
            }
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Shoe item = _shoeService.GetShoeById(id);
            if (item == null)
            {
                return NotFound();
            }

            ShoeDetailsVM shoe = new ShoeDetailsVM()
            {

                Id = item.Id,
                ShoeName = item.ShoeName,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount,
                Description = item.Description,
                Colour = item.Colour,
                Material = item.Material,
            };
            return View(shoe);
        }
        public ActionResult Delete(int id)
        {
            Shoe item = _shoeService.GetShoeById(id);
            if (item == null)
            {
                return NotFound();
            }

            ShoeDeleteVM shoe = new ShoeDeleteVM()
            {

                Id = item.Id,
                ShoeName = item.ShoeName,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount,
                Description = item.Description,
                Colour = item.Colour,
                Material = item.Material,
            };
            return View(shoe);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)

        {
            var deleted = _shoeService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}