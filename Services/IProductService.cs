using JungleApi.Web.Models;
using System.Collections.Generic;

namespace JungleApi.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductCategory> GetProductCategories();
        IEnumerable<ProductSubcategory> GetProductSubcategories(int id);
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(int id, string sort);
    }
}
