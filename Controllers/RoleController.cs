using ecommerce_biu.Data;
using ecommerce_biu.Models;
using ecommerce_biu.Services;
using ecommerce_biu.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController(AppDbContext context) : BaseController<Role>(context)
    {
    }
}
