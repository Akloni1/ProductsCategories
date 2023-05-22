using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using productscategories.ViewModels;
using Microsoft.Extensions.Caching.Distributed;
using productscategories.Redis;
using System.Data;

namespace productscategories.Repository
{
    public class ProductCategorieSqlRepository : IProductCategorieRepository
    {
        private readonly IDistributedCache _cache;
        private readonly IConfiguration _configuration;
        public ProductCategorieSqlRepository(IConfiguration configuration, IDistributedCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }
        /// <summary>
        /// Возвращает список названий продукта и категории соответствующие друг другу с помощью SQL запроса
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
                    nameProductsAndCategories = new List<NamesProductsCategoriesViewModel>();
                    string query = "SELECT Products.Name AS NameProduct, COALESCE(Categories.Name, 'У товара нет категории') AS NameCategory " +
                               "FROM Products " +
                               "LEFT JOIN ProductsCategories ON Products.Id = ProductsCategories.IdProduct " +
                               "LEFT JOIN Categories ON ProductsCategories.IdCategory = Categories.Id";

                    using (SqlConnection connection = new(_configuration.GetConnectionString("ProjectContext")))
                    {
                      
                        /* SqlCommand command = new("GetProductsWithCategories", connection)
                         {
                             CommandType = CommandType.StoredProcedure
                         };*/
                        await connection.OpenAsync();
                        using SqlCommand command = new(query, connection);
                        SqlDataReader reader = await command.ExecuteReaderAsync();

                        while (reader.Read())
                        {
                            string productName = reader.GetString(0);
                            string categoryName = reader.GetString(1);
                            var productAndCategory = new NamesProductsCategoriesViewModel { NameProduct = productName, NameCategory = categoryName };
                            nameProductsAndCategories.Add(productAndCategory);
                        }
                    }
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
                throw new Exception($"Error productscategories.Repository.ProductCategorieSqlRepository.GetNamesProductsAndCategories(): {ex}");
            }
        }
    }
}
