using ecommerce_biu.Data;
using ecommerce_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Repositories
{
    public class ProductRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<Product?> GetProductById(long id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtener todos los Products
        /// </summary>
        /// <returns>Product List</returns>
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByType(String type)
        {
            return await _context.Products.Where(p => p.ProductType == type).ToListAsync();
        }

        /// <summary>
        /// Agregar un Product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>Product added</returns>
        public async Task<Product> AddAsync(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

        /// <summary>
        /// Actualizar un Product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns>Product updated</returns>
        public async Task<Product> UpdateAsync(Product Product)
        {
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
            return Product;
        }

    }
}
