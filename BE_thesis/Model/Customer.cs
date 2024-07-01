using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.Model
{
    [Table("Customer")]
    public class Customer: BaseEntity
    {
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        [Column("email", TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;


        [Column("address", TypeName = "nvarchar(200)")]
        public string Address { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("phone", TypeName = "nvarchar(20)")]
        public string Phone { get; set; } = string.Empty;

    }
}
