using System.ComponentModel.DataAnnotations;

namespace BE_thesis.InputModel
{
    public class ApiLoginInput
    {
        [Required]
        [MinLength(4)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
