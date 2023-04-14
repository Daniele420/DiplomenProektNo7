using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DiplomenProektNo7.Models.Category
{
    public class CategoryPairVM
    {
        public int Id { get; set; }

        [Display(Name = "Category")]

        public string Name { get; set; }
    }
}
