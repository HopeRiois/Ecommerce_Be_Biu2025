using ecommerce_biu.Models;
using ecommerce_biu.Repositories;
using ecommerce_biu.Responses;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce_biu.Services
{
    public class ProductService(ProductRepository productRepository, CategoryService categoryService)
    {
        private readonly ProductRepository _productRepository = productRepository;

        private readonly CategoryService _categoryService = categoryService;

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetById(long id)
        {
            return await _productRepository.GetProductById(id);
        }


        public async Task<List<Product>> GetProductsByType(String type)
        {
            try
            {
                List<Product> response = await _productRepository.GetProductsByType(type);
                if (response.IsNullOrEmpty()) return [];
                return response;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<Product?> CreateProduct(Product product)
        {
            var category = await _categoryService.GetCategory(product.Category.Id);
            if (category != null)
                product.Category = category;

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product?> UpdateProduct(Product product)
        {
            var category = await _categoryService.GetCategory(product.Category.Id);
            if (category != null)
                product.Category = category;

            return await _productRepository.UpdateAsync(product);
        }

        public async Task<List<BuyProductsResponse>> GetProductsForBuying()
        {
            List<BuyProductsResponse> response = [];
            List<Product> products = await _productRepository.GetAllAsync();
            foreach(Product prod in products){
                BuyProductsResponse buy = new()
                {
                    Product = prod,
                    Quantity = 1
                };
                response.Add(buy);
            }

            return response;
        }
    }
}
