using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    [Table("roles")]
    public class Role : BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("role_name")]
        public required string RoleName { get; set; }

        [Column("role_code")]
        public required char RoleCode { get; set; }
    }
}
