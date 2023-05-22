using Microsoft.AspNetCore.Mvc;
using productscategories.Repository;
using System.Diagnostics;

namespace productscategories.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCategorieRepository _productCategorieRepository;
        public ProductController(IProductCategorieRepository productCategorieRepository)
        {
            _productCategorieRepository = productCategorieRepository;
        }
        /// <summary>
        /// Возвращает список названий продукта и категории соответствующие друг другу
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNamesProductsAndCategories()
        {
            var res = await _productCategorieRepository.GetNamesProductsAndCategories();
            return Ok(res);
        }
    }
}
