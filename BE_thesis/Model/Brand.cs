using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.Model
{
    [Table("Brand")]
    public class Brand:BaseEntity
    {
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("origin", TypeName = "nvarchar(100)")]
        public string Origin { get; set; } = string.Empty;

        [Column("address", TypeName = "nvarchar(200)")]
        public string Address { get; set; } = string.Empty;

    }
}
