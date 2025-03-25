using ecommerce_biu.Models;
using ecommerce_biu.Repositories;

namespace ecommerce_biu.Services
{
    public class RoleService(RoleRepository roleRepository)
    {
        private readonly RoleRepository _roleRepository = roleRepository;

        public async Task<Role?> GetRole(long id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

    }
}
