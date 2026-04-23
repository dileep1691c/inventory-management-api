using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class BaseEntity
    {
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column("updated_date")]
        public DateTime? UpdatedDate { get; set; } 

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }
    }
}
