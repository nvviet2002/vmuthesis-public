using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_thesis.InputModel
{
    public class ApiBrandInput
    {

        public int? ID { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }


        [MaxLength(100)]
        public string? Origin { get; set; }

        public string? Address { get; set; }
    }
}
