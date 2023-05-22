using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using productscategories.Controllers;
using productscategories.Repository;
using productscategories.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCategoriesTest
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task GetNamesProductsAndCategories_ReturnsOk()
        {
            // Arrange
            var mockRepository = new Mock<IProductCategorieRepository>();
            var expectedRes = new List<NamesProductsCategoriesViewModel> { };
            mockRepository.Setup(x => x.GetNamesProductsAndCategories()).ReturnsAsync(expectedRes);
            var controller = new ProductController(mockRepository.Object);

            // Act
            var result = await controller.GetNamesProductsAndCategories() as OkObjectResult;
            var actualRes = result?.Value as List<NamesProductsCategoriesViewModel>;

            // Assert
            Assert.Equal(StatusCodes.Status200OK, result?.StatusCode);
            Assert.Equal(expectedRes.Count, actualRes?.Count);
            Assert.Equal(expectedRes, actualRes);
        }
    }
}
