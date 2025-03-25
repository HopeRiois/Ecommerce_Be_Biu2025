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
    public class SaleController(AppDbContext context, SaleService saleService) : BaseController<Sale>(context)
    {
        private readonly SaleService _saleService = saleService;

        [Authorize]
        [HttpPost]
        [Route("make-sale")]
        public async Task<IActionResult> MakeSale(MakeSaleRequest request)
        {
            Sale? sale = await _saleService.MakeSale(request);
            if (sale == null) return NotFound();
            return Ok(sale);
        }
    }
}
