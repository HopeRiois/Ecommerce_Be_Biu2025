using ecommerce_biu.Data;
using ecommerce_biu.Models;
using ecommerce_biu.Services;
using ecommerce_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController (AppDbContext context, ProductService productService) : BaseController<Product>(context)
    {
        private readonly ProductService _productService = productService;

        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-type")]
        public async Task<IActionResult> GetProductsByType(string type) => Ok(await _productService.GetProductsByType(type));

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllProducts() => Ok(await _productService.GetAll());

        [Authorize]
        [HttpGet]
        [Route("get-for-buying")]
        public async Task<IActionResult> GetProductsForBuynig() => Ok(await _productService.GetProductsForBuying());

        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var res = await _productService.UpdateProduct(product);
            if (res == null) return Conflict();
            return Ok(res);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var res = await _productService.CreateProduct(product);
            if (res == null) return Conflict();
            return Ok(res);
        }
    }
}
