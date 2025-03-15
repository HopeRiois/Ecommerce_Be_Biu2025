using ecommerce_biu.Models;
using ecommerce_biu.Repositories;

namespace ecommerce_biu.Services
{
    public class UserService(UserRepository UserRepository)
    {
        private readonly UserRepository _UserRepository = UserRepository;

        public async Task<List<User>> GetAll()
        {
            return await _UserRepository.GetAllAsync();
        }

        public async Task<User> GetById(int id)
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

        public async Task<User> Delete(int id)
        {
            return await _UserRepository.DeleteAsync(id);
        }
    }
}

