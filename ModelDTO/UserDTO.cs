namespace InventoryManagement.ModelDTO
{
    /// <summary>
    /// Data transfer object representing a user returned to clients.
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's first name.
        /// </summary>
        public string FristName { get; set; } = string.Empty;

        /// <summary>
        /// User's last name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// User's email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Identifier of the role associated with the user.
        /// </summary>
        public int RoleId { get; set; }
    }
}
