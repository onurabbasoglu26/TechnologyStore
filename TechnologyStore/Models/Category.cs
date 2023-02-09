using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechnologyStore.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name Not Empty")]
        [StringLength(20, ErrorMessage = "Please only enter 3-20 length characters", MinimumLength = 3)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public bool Status { get; set; } = true;

        public List<Product> Products { get; set; }
    }
}
