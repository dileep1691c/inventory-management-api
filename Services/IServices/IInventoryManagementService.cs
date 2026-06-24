namespace InventoryManagement.Services.IServices
{
    /// <summary>
    /// Defines a generic interface for managing inventory-related operations. This interface provides methods for retrieving, creating, updating, and deleting entities of type T, where T is a class representing an inventory item or entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IInventoryManagementService<T> where T : class
    {
        /// <summary>
        /// Asynchronously retrieves an entity of type T by its unique identifier (id). If the entity is found, it returns the entity; otherwise, it returns null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetAsync(int id);

        /// <summary>
        /// Asynchronously retrieves all entities of type T. It returns an enumerable collection of entities, which may be empty if no entities are found.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T?>> GetAllAsync();

        /// <summary>
        /// Asynchronously creates a new entity of type T. It returns a boolean value indicating whether the creation was successful (true) or not (false).
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(T entity);

        /// <summary>
        /// Asynchronously deletes an entity of type T by its unique identifier (id). If the entity is found and successfully deleted, it completes the operation; otherwise, it may throw an exception or handle the case accordingly.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Asynchronously updates an existing entity of type T. It takes the updated entity as a parameter and performs the update operation. The method does not return a value, but it may throw exceptions if the update fails or if the entity does not exist.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
    }
}
