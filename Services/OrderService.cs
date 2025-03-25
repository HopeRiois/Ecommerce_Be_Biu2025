using ecommerce_biu.Models;
using ecommerce_biu.Repositories;
using ecommerce_biu.Requests;

namespace ecommerce_biu.Services
{
    public class OrderService(OrderRepository OrderRepository, OrderProductService OrderProductService, UserService userService, ProductService productService)
    {
        private readonly OrderRepository _OrderRepository = OrderRepository;

        private readonly OrderProductService _OrderProductService = OrderProductService;

        private readonly UserService _userService = userService;

        private readonly ProductService _productService = productService;

        public async Task<Order?> GetEnableOrder(long idUser)
        {
            return await _OrderRepository.GetCurrentOrder(idUser);
        }

        public async Task<Order?> RemoveProduct(RemoveOrderRequest request)
        {
            Order? order = await _OrderRepository.GetByIdAsync(request.IdOrder);
            if (order == null) return null;

            List<OrderProduct> orderProducts = order.OrderProducts;

            foreach (OrderProduct op in orderProducts)
            {
                if (op.Id == request.IdOrderProduct)
                {
                    //Delete orderProduct
                    await _OrderProductService.RemoveAsync(op.Id);
                    orderProducts.Remove(op);
                    break;
                }
            }
            order.OrderProducts = orderProducts;
            return order;
        }

        public async Task<Order?> ManageOrder(ManageOrderRequest request)
        {
            Product? product = await _productService.GetById(request.IdProduct);
            if (product == null) return null;

            Order? order = await _OrderRepository.GetCurrentOrder(request.IdUser);
            if (order != null)
            {
                List<OrderProduct> orderProducts = order.OrderProducts;
                bool orderExists = false;
                foreach (OrderProduct op in orderProducts)
                {
                    if (op.Product.Id == request.IdProduct)
                    {
                        //Update order if needed
                        orderExists = true;
                        op.Amount = request.IsAdding ? op.Amount + request.Amount : op.Amount - request.Amount;
                        if (op.Amount == 0)
                        {
                            //Delete orderProduct
                            await _OrderProductService.RemoveAsync(op.Id);
                            orderProducts.Remove(op);
                            break;
                        }
                        else
                        {
                            await _OrderProductService.UpdateAsync(op);
                            break;
                        }
                    }
                }


                if (!orderExists)
                {
                    //Create new order product
                    OrderProduct prodToAdd = new()
                    {
                        Id = 0,
                        OrderId = order.Id,
                        Amount = request.Amount,
                        Product = product
                    };
                    prodToAdd = await _OrderProductService.AddAsync(prodToAdd);
                    orderProducts.Add(prodToAdd);
                }
                order.OrderProducts = orderProducts;
                return order;
            }
            else
            {
                User? user = await _userService.GetById(request.IdUser);
                if (user == null) return null;
                //Add order manually
                order = new()
                {
                    Id = 0,
                    OrderDate = DateTime.Now,
                    Status = "pendiente",
                    User = user,
                    OrderProducts = []
                };
                order = await _OrderRepository.CreateManually(order);
                if (order == null) return null;

                //Save order products
                List<OrderProduct> orderProducts = [];
                OrderProduct prodToAdd = new()
                {
                    Id = 0,
                    OrderId = order.Id,
                    Amount = request.Amount,
                    Product = product
                };
                prodToAdd = await _OrderProductService.AddAsync(prodToAdd);
                orderProducts.Add(prodToAdd);

                order.OrderProducts = orderProducts;
                return order;
            }

        }
        public async Task<Order> UpdateAsync(Order order)
        {
            return await _OrderRepository.UpdateAsync(order);
        }
    }
}
