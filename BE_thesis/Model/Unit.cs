using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_thesis.Model
{
    [Table("Unit")]
    public class Unit: BaseEntity
    {
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("description", TypeName = "nvarchar(MAX)")]
        public string Description { get; set; } = string.Empty;

    }
}
