using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Domain
{
    public class Shoe
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ShoeName { get; set; }
        [Required]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Picture { get; set; }

        [Required]
        [Range(0, 5000)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        [MaxLength(20)]
        public string Colour { get; set; }

        [Required]
        [MaxLength(50)]
        public string Material { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
