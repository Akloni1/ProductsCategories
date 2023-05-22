

namespace productscategories.Models
{
    public class ProductsCategories
    {

        public int IdProduct { get; set; }

        public int IdCategory { get; set; }

        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }

    }
}
