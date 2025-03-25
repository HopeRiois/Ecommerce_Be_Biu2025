using ecommerce_biu.Data;
using ecommerce_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Repositories
{
    public class OrderProductRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;

        public async Task<List<OrderProduct>> GetOrderProductsByIdOrder(long id)
        {
            return await _context.OrderProducts.Where(p => p.OrderId == id).ToListAsync();
        }

        public async Task<OrderProduct> AddAsync(OrderProduct op)
        {
            _context.OrderProducts.Add(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<OrderProduct?> DeleteAsync(long id)
        {
            var op = await _context.OrderProducts.FindAsync(id);
            if (op == null) return null;

            _context.OrderProducts.Remove(op);
            await _context.SaveChangesAsync();
            return op;
        }

        public async Task<OrderProduct> UpdateAsync(OrderProduct op)
        {
            _context.OrderProducts.Update(op);
            await _context.SaveChangesAsync();
            return op;
        }

    }
}
