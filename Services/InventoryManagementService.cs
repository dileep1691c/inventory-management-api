using InventoryManagement.Repository.IRepository;
using InventoryManagement.Services.IServices;

namespace InventoryManagement.Services
{
    public class InventoryManagementService<T> : IInventoryManagementService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        public InventoryManagementService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<bool> CreateAsync(T entity) => _repository.CreateAsync(entity);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);

        public Task<IEnumerable<T?>> GetAllAsync() => _repository.GetAllAsync();

        public Task<T?> GetAsync(int id) => _repository.GetAsync(id);

        public Task updateAsync(T entity) => _repository.UpdateAsync(entity);
    }
}
