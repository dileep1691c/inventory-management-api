using InventoryManagement.Models;

namespace InventoryManagement.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmail(string email);
    }
}
