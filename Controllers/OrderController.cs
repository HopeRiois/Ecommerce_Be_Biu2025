using ecommerce_biu.Data;
using ecommerce_biu.Models;
using ecommerce_biu.Requests;
using ecommerce_biu.Services;
using ecommerce_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(AppDbContext context, OrderService orderService) : BaseController<Order>(context)
    {
        private readonly OrderService _orderService = orderService;

        [Authorize]
        [HttpPost]
        [Route("manage-order")]
        public async Task<IActionResult> ManageOrder(ManageOrderRequest request)
        {
            Order? order = await _orderService.ManageOrder(request);
            if(order == null) return StatusCode(500);
            return Ok(order);
        }

        [Authorize]
        [HttpPost]
        [Route("remove-product")]
        public async Task<IActionResult> RemoveProduct(RemoveOrderRequest request)
        {
            Order? order = await _orderService.RemoveProduct(request);
            if (order == null) return StatusCode(500);
            return Ok(order);
        }

        [Authorize]
        [HttpGet]
        [Route("get-enable-order")]
        public async Task<IActionResult> GetEnableOrder(long idUser)
        {
            Order? order = await _orderService.GetEnableOrder(idUser);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
