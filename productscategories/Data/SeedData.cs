using Microsoft.EntityFrameworkCore;
using productscategories.Models;

namespace productscategories.Data
{
    public class SeedData
    {
        public async static void Initialize(IConfiguration configuration)
        {
            using (var context = new ProjectContext(configuration))
            {
                if (!context.Products.Any() && !context.Categories.Any() && !context.ProductsCategories.Any())
                {
                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Product 1",
                            Price = 3100000,
                            Description = "Description 1",
                            ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 1",
                                           Description = "Description 1",
                                       }
                                  }
                            }
                        },
                         new Product
                         {
                             Name = "Product 2",
                             Price = 3100000,
                             Description = "Description 2",
                             ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 2",
                                           Description = "Description 2",
                                       }
                                  }
                            }
                         },
                          new Product
                          {
                              Name = "Product 3",
                              Price = 3100000,
                              Description = "Description 3",
                              ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 3",
                                           Description = "Description 3",
                                       }
                                  }
                            }
                          },
                           new Product
                           {
                               Name = "Product 4",
                               Price = 3100000,
                               Description = "Description 4",
                               ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 4",
                                           Description = "Description 4",
                                       }
                                  }
                            }
                           },
                            new Product
                            {
                                Name = "Product 5",
                                Price = 3100000,
                                Description = "Description 5",
                                ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 5",
                                           Description = "Description 5",
                                       }
                                  }
                            }
                            },
                             new Product
                             {
                                 Name = "Product 6",
                                 Price = 3100000,
                                 Description = "Description 6",
                                 ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 6",
                                           Description = "Description 6",
                                       }
                                  }
                            }
                             },
                              new Product
                              {
                                  Name = "Product 7",
                                  Price = 3100000,
                                  Description = "Description 7",
                                  ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 7",
                                           Description = "Description 7",
                                       }
                                  }
                            }
                              },
                               new Product
                               {
                                   Name = "Product 8",
                                   Price = 3100000,
                                   Description = "Description 9",
                                   ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 9",
                                           Description = "Description 9",
                                       }
                                  }
                            }
                               },
                                new Product
                                {
                                    Name = "Product 10",
                                    Price = 3100000,
                                    Description = "Description 10",
                                    ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 10",
                                           Description = "Description 10",
                                       }
                                  }
                            }
                                },
                                 new Product
                                 {
                                     Name = "Product 11",
                                     Price = 3100000,
                                     Description = "Description 11",
                                     ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 11",
                                           Description = "Description 11",
                                       }
                                  }
                            }
                                 },
                                  new Product
                                  {
                                      Name = "Product 12",
                                      Price = 3100000,
                                      Description = "Description 12",
                                      ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 12",
                                           Description = "Description 12",
                                       }
                                  }
                            }
                                  },
                                   new Product
                                   {
                                       Name = "Product 13",
                                       Price = 3100000,
                                       Description = "Description 13",
                                       ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 13",
                                           Description = "Description 13",
                                       }
                                  }
                            }
                                   },
                                    new Product
                                    {
                                        Name = "Product 14",
                                        Price = 3100000,
                                        Description = "Description 14",
                                        ProductsCategories = new List<ProductsCategories>()
                            {
                                  new ProductsCategories()
                                  {
                                       Category= new Category()
                                       {
                                           Name = "Category 14",
                                           Description = "Description 14",
                                       }
                                  }
                            }
                                    },
                                     new Product
                                     {
                                         Name = "Product 15",
                                         Price = 3100000,
                                         Description = "Description 15",
                                     }
                        );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
