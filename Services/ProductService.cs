using JungleApi.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace JungleApi.Web.Services
{
    public class ProductService : ServicesBase, IProductService
    {
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return _dbContext.ProductCategories.ToList();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList().OrderBy(p => p.ProductSubcategoryId);
        }

        public IEnumerable<Product> GetProducts(int id, string sort)
        {
            if (sort == "sort-asc")
            {
                return _dbContext.Products.Where(p => p.ProductSubcategoryId.Equals(id)).OrderBy(p => p.Price).ToList();
            }
            else if (sort == "sort-desc")
            {
                return _dbContext.Products.Where(p => p.ProductSubcategoryId.Equals(id)).OrderByDescending(p => p.Price).ToList();
            }
            else
            {
                return _dbContext.Products.Where(p => p.ProductSubcategoryId.Equals(id)).ToList();
            }
        }

        public IEnumerable<ProductSubcategory> GetProductSubcategories(int id)
        {
            return _dbContext.ProductSubcategories.Where(p => p.ProductCategoryId.Equals(id)).ToList();
        }
    }
}
