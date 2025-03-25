using ecommerce_biu.Models;
using ecommerce_biu.Repositories;

namespace ecommerce_biu.Services
{
    public class OrderProductService(OrderProductRepository OrderProductRepository)
    {
        private readonly OrderProductRepository _OrderProductRepository = OrderProductRepository;

        public async Task<List<OrderProduct>> GetOrderProduct(long idOrder)
        {
            return await _OrderProductRepository.GetOrderProductsByIdOrder(idOrder);
        }

        public async Task<OrderProduct> AddAsync(OrderProduct op)
        {
            return await _OrderProductRepository.AddAsync(op);
        }

        public async Task<OrderProduct> UpdateAsync(OrderProduct op)
        {
            return await _OrderProductRepository.UpdateAsync(op);
        }

        public async Task<OrderProduct?> RemoveAsync(long idOp)
        {
            return await _OrderProductRepository.DeleteAsync(idOp);
        }

    }
}
