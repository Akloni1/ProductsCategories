using Microsoft.EntityFrameworkCore;
using productscategories.Data;
using productscategories.ViewModels;
using Microsoft.Extensions.Caching.Distributed;
using productscategories.Redis;

namespace productscategories.Repository
{
    public class ProductCategorieEntityRepository : IProductCategorieRepository
    {
        private readonly ProjectContext _context;
        private readonly IDistributedCache _cache;
        public ProductCategorieEntityRepository(ProjectContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        /// <summary>
        /// Возвращает список названий продукта и категории соответствующие друг другу с помощью библиотеки EntityFrameworkCore
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<NamesProductsCategoriesViewModel>> GetNamesProductsAndCategories()
        {
            try
            {
                var nameProductsAndCategories = await _cache.GetRecordAsync<List<NamesProductsCategoriesViewModel>>(typeof(NamesProductsCategoriesViewModel).Name);

                if (nameProductsAndCategories is null)
                {
                    nameProductsAndCategories = await (from p in _context.Products
                                                       join pc in _context.ProductsCategories
                                                       on p.Id equals pc.IdProduct into ppc_join
                                                       from pc in ppc_join.DefaultIfEmpty()
                                                       join c in _context.Categories
                                                       on pc.IdCategory equals c.Id into pcc_join
                                                       from c in pcc_join.DefaultIfEmpty()
                                                       select new NamesProductsCategoriesViewModel { NameProduct = p.Name, NameCategory = c != null ? c.Name : "The product has no category" }).ToListAsync();

                    await _cache.SetRecordAsync(typeof(NamesProductsCategoriesViewModel).Name, nameProductsAndCategories);
                }
                else
                {
                    return nameProductsAndCategories;
                }
                return nameProductsAndCategories;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error productscategories.Repository.ProductCategorieEntityRepository.GetNamesProductsAndCategories(): {ex}");
            }
        }
    }
}
