using System.ComponentModel.DataAnnotations;

namespace BE_thesis.InputModel
{
    public class ApiUnitInput
    {
        public int? ID { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
