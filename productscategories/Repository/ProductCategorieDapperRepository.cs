using Dapper;
using Microsoft.Data.SqlClient;
using productscategories.ViewModels;
using Microsoft.Extensions.Caching.Distributed;
using productscategories.Redis;

namespace productscategories.Repository
{

    public class ProductCategorieDapperRepository : IProductCategorieRepository
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;
        public ProductCategorieDapperRepository(IConfiguration configuration, IDistributedCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }
        /// <summary>
        /// Возвращает список названий продукта и категории соответствующие друг другу с помощью библиотеки Dapper
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<NamesProductsCategoriesViewModel>> GetNamesProductsAndCategories()
        {
            try
            {
                IEnumerable<NamesProductsCategoriesViewModel>? nameProductsAndCategories = await _cache.GetRecordAsync<List<NamesProductsCategoriesViewModel>>(typeof(NamesProductsCategoriesViewModel).Name);

                if (nameProductsAndCategories is null)
                {
                    using SqlConnection connection = new(_configuration.GetConnectionString("ProjectContext"));
                    nameProductsAndCategories = await connection.QueryAsync<NamesProductsCategoriesViewModel>(@"SELECT p.Name AS NameProduct, 
                                                                                          COALESCE(c.Name, 'The product has no category') AS NameCategory 
                                                                                          FROM Products p
                                                                                          LEFT JOIN ProductsCategories pc ON p.Id = pc.IdProduct
                                                                                          LEFT JOIN Categories c ON pc.IdCategory = c.Id");

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
                throw new Exception($"Error productscategories.Repository.ProductCategorieDapperRepository.GetNamesProductsAndCategories(): {ex}");
            }
        }
    }
}
