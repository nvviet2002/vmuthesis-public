using BE_thesis.Enum;
using BE_thesis.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_thesis.OutputModel
{
    public class ApiProductOutput
    {
        public int ID { get; set; }
        public string Identification { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string SKU { get; set; }

        public ProductType Type { get; set; }
        public string QRCode { get; set; }

        public string Avatar { get; set; }
        public double Inventory { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        public string Category { get; set; }

        public string Unit { get; set; }
        public string Brand { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
