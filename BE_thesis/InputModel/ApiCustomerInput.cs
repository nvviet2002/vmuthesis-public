
using System.ComponentModel.DataAnnotations;

namespace BE_thesis.InputModel
{
    public class ApiCustomerInput
    {
        public int? ID { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        public string? Address { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

    }
}
