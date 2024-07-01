using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.Model
{
    [Table("Category")]
    public class Category: BaseEntity
    {
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("description",TypeName = "nvarchar(MAX)")]
        public string Description { get; set; } = string.Empty;

    }
}
