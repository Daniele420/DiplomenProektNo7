using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomenProektNo7.Domain
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string BrandName { get; set; }
        public virtual IEnumerable<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
