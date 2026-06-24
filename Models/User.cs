using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Represents a user entity in the application. This class is mapped to the "users" table in the database and contains properties that correspond to the columns in the table.
    /// </summary>
    [Table("users")]
    public class User : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user. This property is mapped to the "id" column in the "users" table.
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user. This property is mapped to the "first_name" column in the "users" table.
        /// </summary>
        [Column("first_name")]
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user. This property is mapped to the "last_name" column in the "users" table.
        /// </summary>
        [Column("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user. This property is mapped to the "email" column in the "users" table.
        /// </summary>
        [Column("email")]
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the address of the user. This property is mapped to the "address" column in the "users" table.
        /// </summary>
        [Column("address")]
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the state of the user. This property is mapped to the "state" column in the "users" table.
        /// </summary>
        [Column("state")]   
        public string? State { get; set; }

        /// <summary>
        /// Gets or sets the city of the user. This property is mapped to the "city" column in the "users" table.
        /// </summary>
        [Column("city")]
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the password of the user. This property is mapped to the "password" column in the "users" table.
        /// </summary>
        [Column("password")]
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user. This property is mapped to the "phone_number" column in the "users" table.
        /// </summary>
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the salt value used for password hashing. This property is mapped to the "salt" column in the "users" table.
        /// </summary>
        [Column("salt")]
        public required string Salt { get; set; }

        /// <summary>
        /// Gets or sets the role identifier associated with the user. This property is mapped to the "role_id" column in the "users" table.
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }
    }
}
