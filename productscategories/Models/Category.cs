using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace productscategories.Models
{
    public class Category
    {
        public Category()
        {
            ProductsCategories = new HashSet<ProductsCategories>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Имя категории не может быть пустое")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<ProductsCategories> ProductsCategories { get; set; }

    }
}
