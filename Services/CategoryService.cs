using ecommerce_biu.Models;
using ecommerce_biu.Repositories;

namespace ecommerce_biu.Services
{
    public class CategoryService(CategoryRepository catRepository)
    {
        private readonly CategoryRepository _catRepository = catRepository;

        public async Task<Category?> GetCategory(long id)
        {
            return await _catRepository.GetByIdAsync(id);
        }
    }
}
