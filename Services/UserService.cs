using InventoryManagement.Models;
using InventoryManagement.Repository.IRepository;
using InventoryManagement.Services.IServices;

namespace InventoryManagement.Services
{
    public class UserService : InventoryManagementService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IRepository<User> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
    }
}
