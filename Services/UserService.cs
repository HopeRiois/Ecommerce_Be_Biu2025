using ecommerce_biu.Models;
using ecommerce_biu.Repositories;

namespace ecommerce_biu.Services
{
    public class UserService(UserRepository UserRepository, RoleService roleService)
    {
        private readonly UserRepository _UserRepository = UserRepository;

        private readonly RoleService _roleService = roleService;

        public async Task<Boolean> CheckIfEmailExists(String email)
        {
            return await _UserRepository.CheckIfEmailExists(email);
        }

        public async Task<User?> CreateUser(User user)
        {
            if (await _UserRepository.CheckIfUserOrEmailExists(user.UserName, user.Email))
                return null;

            var rol = await _roleService.GetRole(user.Rol.Id);
            if (rol != null)
                user.Rol = rol;

            return await _UserRepository.AddAsync(user);

        }

        public async Task<User> UpdatePassword(String email, String password)
        {
            return await _UserRepository.UpdatePassword(email, password);
        }

        public async Task<List<User>> GetAll()
        {
            return await _UserRepository.GetAllAsync();
        }

        public async Task<User?> GetById(long id)
        {
            return await _UserRepository.GetByIdAsync(id);
        }

        public async Task<User> Create(User User)
        {
            return await _UserRepository.AddAsync(User);
        }

        public async Task<User> Update(User User)
        {
            return await _UserRepository.UpdateAsync(User);
        }

        public async Task<User?> Delete(int id)
        {
            return await _UserRepository.DeleteAsync(id);
        }
    }
}

