using ecommerce_biu.Data;
using ecommerce_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Repositories
{
    public class OrderRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<Order?> GetByIdAsync(long id)
        {
            return await _context.Orders.FindAsync(id);
        }

        /// <summary>
        /// Agregar un pedido
        /// </summary>
        /// <param name="Order"></param>
        /// <returns>Order added</returns>
        public async Task<Order> AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order; 
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetCurrentOrder(long idUser)
        {
            return await _context.Orders.Where(o => o.User.Id == idUser && o.Status.Equals("pendiente")).FirstOrDefaultAsync();
        }

        public async Task<Order?> CreateManually(Order order)
        {
            string query = "INSERT INTO Orders (orderDate, status, userId) VALUES ({0}, {1}, {2})";
            int result = await _context.Database.ExecuteSqlRawAsync(query, order.OrderDate, order.Status, order.User.Id);
            if (result > 0)
                return await GetCurrentOrder(order.User.Id);
            return null;
        }

    }
}
