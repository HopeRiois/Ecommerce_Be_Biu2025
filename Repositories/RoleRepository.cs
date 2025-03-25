using ecommerce_biu.Data;
using ecommerce_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Repositories
{
    public class RoleRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        /// <summary>
        /// Obtener un Role por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Role</returns>
        public async Task<Role?> GetByIdAsync(long id)
        {
            return await _context.Rols.FindAsync(id);
        }
    }
}
