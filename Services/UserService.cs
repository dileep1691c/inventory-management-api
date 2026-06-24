using InventoryManagement.Models;
using InventoryManagement.Repository.IRepository;
using InventoryManagement.Services.IServices;

namespace InventoryManagement.Services
{
    /// <summary>
    /// Service class responsible for managing user-related operations, including retrieving user information and interacting with the user repository.
    /// </summary>
    public class UserService : InventoryManagementService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class with the specified user repository and base repository.
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="userRepository"></param>
        public UserService(IRepository<User> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get a user by their email address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }
    }
}
