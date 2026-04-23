namespace InventoryManagement.Services.IServices
{
    public interface IInventoryManagementService<T> where T : class
    {
        Task<T?> GetAsync(int id);

        Task<IEnumerable<T?>> GetAllAsync();
        Task<bool> CreateAsync(T entity);

        Task DeleteAsync(int id);

        Task updateAsync(T entity);
    }
}
