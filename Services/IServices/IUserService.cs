using InventoryManagement.Models;

namespace InventoryManagement.Services.IServices
{
    public interface IUserService : IInventoryManagementService<User>
    {
        Task<User?> GetUserByEmail(string email);
    }
}
