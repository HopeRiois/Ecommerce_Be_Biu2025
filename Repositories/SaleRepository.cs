using ecommerce_biu.Data;
using ecommerce_biu.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_biu.Repositories
{
    public class SaleRepository(AppDbContext context)
    {
        private readonly AppDbContext _context = context;


        public async Task<Sale> AddAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}
