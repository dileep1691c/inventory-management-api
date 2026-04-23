namespace InventoryManagement.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(int id);

        Task<IEnumerable<T?>> GetAllAsync();

        Task DeleteAsync(int id);

        Task<bool> CreateAsync(T entity);

        Task UpdateAsync(T entity);
    }
}
