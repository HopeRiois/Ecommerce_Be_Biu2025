using ecommerce_biu.Models;
using ecommerce_biu.Repositories;
using ecommerce_biu.Requests;
using ecommerce_biu.Responses;
using ecommerce_biu.Utils;

namespace ecommerce_biu.Services
{
    public sealed class AuthService(UserRepository userRepository, JwtUtils tokenProvider, Encryption encryption)
    {
        private readonly Encryption _encryption = encryption;

        private readonly UserRepository _userRepository = userRepository;

        public async Task<AuthResponse?> HandleLogin(AuthRequest request)
        {
            try
            {
                User user = await _userRepository.Login(request.UserName, _encryption.EncryptAES256(request.Password));
                if (user == null) return null;

                AuthResponse response = tokenProvider.Generate(user);
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
