using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public required string FirstName { get; set; }
        
        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("email")]
        public required string Email { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        [Column("state")]   
        public string? State { get; set; }

        [Column("city")]
        public string? City { get; set; }
        
        [Column("password")]
        public required string Password { get; set; }
        
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("salt")]
        public required string Salt { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }
    }
}
