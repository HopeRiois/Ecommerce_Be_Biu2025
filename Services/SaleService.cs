using ecommerce_biu.Models;
using ecommerce_biu.Repositories;
using ecommerce_biu.Requests;

namespace ecommerce_biu.Services
{
    public class SaleService(SaleRepository SaleRepository, OrderService OrderService)
    {
        private readonly SaleRepository _SaleRepository = SaleRepository;

        private readonly OrderService _OrderService = OrderService;

        public async Task<Sale?> MakeSale(MakeSaleRequest request)
        {
            var order = await _OrderService.GetEnableOrder(request.IdUser);
            if (order == null)
                return null;
            order.Status = "pagado";
            await _OrderService.UpdateAsync(order);

            Sale sale = new()
            {
                Id = 0,
                Order = order,
                SaleDate = DateTime.Now,
                Status = "pagado"
            };
            return await _SaleRepository.AddAsync(sale);
        }
    }
}
