using JungleApi.Web.Models;
using JungleApi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JungleApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IProductService _productService;

        public ProductCategoryController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("categories")]
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return _productService.GetProductCategories();
        }

        [HttpGet("subcategories/{id}")]
        public IEnumerable<ProductSubcategory> GetProductSubcategories([FromRoute] int id)
        {
            return _productService.GetProductSubcategories(id);
        }

        [HttpGet("products/{id}/{sort}")]
        public IEnumerable<Product> GetProducts([FromRoute] int id, [FromRoute] string sort)
        {
            return _productService.GetProducts(id, sort);
        }

        [HttpGet("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
    }
}