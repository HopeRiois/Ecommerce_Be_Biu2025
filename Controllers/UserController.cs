using ecommerce_biu.Data;
using ecommerce_biu.Models;
using ecommerce_biu.Repositories;
using ecommerce_biu.Services;
using ecommerce_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce_biu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(Encryption encryption, UserService userService, AppDbContext context) : BaseController<User>(context)
    {
        private readonly Encryption _encryption = encryption;

        private readonly UserService _UserService = userService;

        [AllowAnonymous]
        [HttpGet]
        [Route("encrypt")]
        public IActionResult EncryptPassword(string password) => Ok(_encryption.EncryptAES256(password));

        [AllowAnonymous]
        [HttpGet]
        [Route("decrypt")]
        public IActionResult DecryptPassword(string password) => Ok(_encryption.DecryptAES256(password));

        [AllowAnonymous]
        [HttpGet]
        [Route("check-email")]
        public async Task<IActionResult> CheckIfEmailExists(String email) => Ok(await _UserService.CheckIfEmailExists(email));

        [AllowAnonymous]
        [HttpGet]
        [Route("reset-password")]
        public async Task<IActionResult> ResetPassword(String email, String password) => Ok(await _UserService.UpdatePassword(email, _encryption.EncryptAES256(password)));

        [AllowAnonymous]
        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUser(User? user)
        {
            user!.Password = _encryption.EncryptAES256(user.Password);
            user = await _UserService.CreateUser(user);
            if (user == null) return Conflict();
            return Ok(user);
        }

    }
}

