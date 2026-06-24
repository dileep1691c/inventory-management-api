using InventoryManagement.Models;

namespace InventoryManagement.Services.IServices
{
    /// <summary>
    /// Defines the contract for a user service that provides operations related to user management, including retrieving user information by email.
    /// </summary>
    public interface IUserService : IInventoryManagementService<User>
    {
        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<User?> GetUserByEmail(string email);
    }
}
