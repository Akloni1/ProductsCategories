using System.ComponentModel.DataAnnotations;
using System.Net;

namespace productscategories.Models
{
    public class Product
    {

        public Product()
        {
            ProductsCategories = new HashSet<ProductsCategories>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя продукта не может быть пустое")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public virtual ICollection<ProductsCategories> ProductsCategories { get; set; }
    }
}
