using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_thesis.Model
{
    public class BaseEntity
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
