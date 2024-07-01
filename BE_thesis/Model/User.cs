using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BE_thesis.Model
{
    public class User: IdentityUser
    {
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("address", TypeName = "nvarchar(200)")]
        public string Address { get; set; } = string.Empty;

        [Column("avatar", TypeName = "nvarchar(MAX)")]
        public string Avatar { get; set; } = string.Empty;

        [Column("jwt", TypeName = "nvarchar(MAX)")]
        public string? Jwt { get; set; } = string.Empty;

        [Column("active")]
        public bool Active { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [Column("is_deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
