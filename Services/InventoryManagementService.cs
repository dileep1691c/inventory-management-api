using InventoryManagement.Repository.IRepository;
using InventoryManagement.Services.IServices;

namespace InventoryManagement.Services
{
    /// <summary>
    /// Represents a generic service for managing inventory-related operations. This service provides methods for retrieving, creating, updating, and deleting entities of type T, where T is a class representing an inventory item or entity. It relies on an underlying repository to perform the actual data access operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InventoryManagementService<T> : IInventoryManagementService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManagementService{T}"/> class with the specified repository. The repository is used to perform data access operations for entities of type T.
        /// </summary>
        /// <param name="repository"></param>
        public InventoryManagementService(IRepository<T> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates a new entity of type T in the underlying data store. This method delegates the creation operation to the repository and returns a boolean indicating whether the creation was successful.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<bool> CreateAsync(T entity) => _repository.CreateAsync(entity);

        /// <summary>
        /// Deletes an entity of type T from the underlying data store based on its unique identifier (id). This method delegates the deletion operation to the repository. If the entity is found and successfully deleted, it completes the operation; otherwise, it may throw an exception or handle the case accordingly.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);

        /// <summary>
        /// Retrieves all entities of type T from the underlying data store. This method delegates the retrieval operation to the repository and returns an enumerable collection of entities. If no entities are found, it may return an empty collection.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T?>> GetAllAsync() => _repository.GetAllAsync();

        /// <summary>
        /// Retrieves a single entity of type T from the underlying data store based on its unique identifier (id). This method delegates the retrieval operation to the repository and returns the entity if found; otherwise, it may return null or handle the case accordingly.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T?> GetAsync(int id) => _repository.GetAsync(id);

        /// <summary>
        /// Updates an existing entity of type T in the underlying data store. This method delegates the update operation to the repository. If the entity is found and successfully updated, it completes the operation; otherwise, it may throw an exception or handle the case accordingly.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task UpdateAsync(T entity) => _repository.UpdateAsync(entity);
    }
}
