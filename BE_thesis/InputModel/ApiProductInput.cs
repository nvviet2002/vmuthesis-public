using BE_thesis.Enum;
using BE_thesis.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_thesis.InputModel
{
    public class ApiProductInput
    {
        public int? ID { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? SKU { get; set; }
        public ProductType? Type { get; set; }
        public string? QRCode { get; set; }
        public IFormFile? Avatar { get; set; }
        public double? Inventory { get; set; }
        public double? Price { get; set; }
        public bool? Active { get; set; }
        public int? CategoryId { get; set; }
        public int? UnitId { get; set; }
        public int? BrandId { get; set; }

     }
}