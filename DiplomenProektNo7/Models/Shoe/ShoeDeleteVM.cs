using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace DiplomenProektNo7.Models.Shoe
{
    public class ShoeDeleteVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Shoe Name")]
        public string ShoeName { get; set; }

        public int BrandId { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Display(Name = "Material")]
        public string Material { get; set; }
    }
}
