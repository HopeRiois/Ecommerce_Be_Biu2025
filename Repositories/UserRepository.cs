using ecommerce_biu.Data;
using ecommerce_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Repositories
{
    public class UserRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        /// <summary>
        /// Obtener todos los Users
        /// </summary>
        /// <returns>User List</returns>
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Obtener un User por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        /// <summary>
        /// Agregar un User
        /// </summary>
        /// <param name="User"></param>
        /// <returns>User added</returns>
        public async Task<User> AddAsync(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        /// <summary>
        /// Actualizar un User
        /// </summary>
        /// <param name="User"></param>
        /// <returns>User updated</returns>
        public async Task<User> UpdateAsync(User User)
        {
            _context.Users.Update(User);
            await _context.SaveChangesAsync();
            return User;
        }

        /// <summary>
        /// Eliminar un User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User deleted</returns>
        public async Task<User> DeleteAsync(int id)
        {
            var User = await _context.Users.FindAsync(id);
            if (User == null) return null;

            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return User;
        }
    
    }
}
