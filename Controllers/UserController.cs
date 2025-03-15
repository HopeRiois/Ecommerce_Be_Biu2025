using ecommerce_biu.Data;
using ecommerce_biu.Models;
using ecommerce_biu.Services;
using ecommerce_biu.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(Encryption encryption, UserService userService, AppDbContext context) : BaseController<User>(context)
    {
        private readonly Encryption _encryption = encryption;

        private readonly UserService _UserService = userService;

        [HttpGet]
        [Route("encrypt")]
        public IActionResult EncryptPassword(string password) => Ok(_encryption.EncryptAES256(password));

        [HttpGet]
        [Route("decrypt")]
        public IActionResult DecryptPassword(string password) => Ok(_encryption.DecryptAES256(password));

      
    }
}

