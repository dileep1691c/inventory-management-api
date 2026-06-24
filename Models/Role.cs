using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Represents a role entity in the application. This class is mapped to the "roles" table in the database and contains properties that correspond to the columns in the table.
    /// </summary>
    [Table("roles")]
    public class Role : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the role. This property is mapped to the "id" column in the "roles" table.
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the role. This property is mapped to the "role_name" column in the "roles" table.
        /// </summary>
        [Column("role_name")]
        public required string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the code associated with the role. This property is mapped to the "role_code" column in the "roles" table.
        /// </summary>
        [Column("role_code")]
        public required char RoleCode { get; set; }
    }
}
