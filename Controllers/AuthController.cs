using ecommerce_biu.Data;
using ecommerce_biu.Models;
using ecommerce_biu.Requests;
using ecommerce_biu.Responses;
using ecommerce_biu.Services;
using ecommerce_biu.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce_biu.Controllers
{
    [ApiController]
    [Route("auth")]
    public sealed class AuthController(AuthService authService) : ControllerBase
    {

        private readonly AuthService _authService = authService;

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> HandleLogin(AuthRequest request)
        {
            AuthResponse? response = await _authService.HandleLogin(request);
            if (response == null) return Unauthorized();
            return Ok(response);
        }

    }
}
