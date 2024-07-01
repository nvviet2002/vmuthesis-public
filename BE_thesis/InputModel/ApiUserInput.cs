using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BE_thesis.Enum;

namespace BE_thesis.InputModel
{
    public class ApiUserInput
    {
        [MaxLength(50)]
        public string? ID { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Address { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        public IFormFile? Avatar { get; set; }

        public bool? Active { get; set; }

        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
