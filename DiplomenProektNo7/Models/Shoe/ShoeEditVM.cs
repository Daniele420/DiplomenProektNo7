using Castle.Components.DictionaryAdapter;
using DiplomenProektNo7.Models.Brand;
using DiplomenProektNo7.Models.Category;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace DiplomenProektNo7.Models.Shoe
{
    public class ShoeEditVM
    {
        public ShoeEditVM() 
        {

            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Shoe Name")]
        public string ShoeName { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual List <CategoryPairVM> Categories { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Required]
        [Range(0, 5000)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Material")]
        public string Material { get; set; }
    }
}
