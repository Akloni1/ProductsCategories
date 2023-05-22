using productscategories.Models;
using productscategories.ViewModels;

namespace productscategories.Repository
{
    public interface IProductCategorieRepository
    {
        /// <summary>
        /// Возвращает список названий продукта и категории соответствующие друг другу  
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NamesProductsCategoriesViewModel>> GetNamesProductsAndCategories();
    }
}
