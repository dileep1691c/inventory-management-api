using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository
{
    public class UserRepository: IUserRepository
    {
        private AppDBContext _dbContext;
        public UserRepository(AppDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
