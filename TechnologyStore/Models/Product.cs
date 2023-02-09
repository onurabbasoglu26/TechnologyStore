using System.ComponentModel.DataAnnotations;

namespace TechnologyStore.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name Not Empty")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Price Not Empty")]
        public double ProductPrice { get; set; }

        [Required(ErrorMessage = "Stock Not Empty")]
        public int ProductStock { get; set; }

        public string ImageURL { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
