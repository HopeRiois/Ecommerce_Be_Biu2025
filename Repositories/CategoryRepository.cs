using ecommerce_biu.Data;
using ecommerce_biu.Models;

namespace ecommerce_biu.Repositories
{
    public class CategoryRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        /// <summary>
        /// Obtener un Category por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category</returns>
        public async Task<Category?> GetByIdAsync(long id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
