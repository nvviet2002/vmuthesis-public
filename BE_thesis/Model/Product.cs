using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BE_thesis.Enum;

namespace BE_thesis.Model
{
    [Table("Product")]
    public class Product: BaseEntity
    {
        [Column("identification")]
        [Index(IsUnique = true)]
        public string Identification { get; set; } = "";

        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("description", TypeName = "nvarchar(MAX)")]
        public string Description { get; set; } = string.Empty;
        [MaxLength(50)]
        [Column("sku", TypeName = "nvarchar(50)")]
        public string SKU { get; set; } = string.Empty;

        [Column("type")]
        public ProductType Type { get; set; } = ProductType.Code;
        [Column("qrcode", TypeName = "nvarchar(MAX)")]
        public string QRCode { get; set; } = string.Empty;

        [Column("avatar", TypeName = "nvarchar(MAX)")]
        public string Avatar { get; set; } = string.Empty;
        [Column("inventory")]
        public double Inventory { get; set; } = 0.0;
        [Column("price")]
        public double Price { get; set; } = 0.0;
        [Column("active")]
        public bool Active { get; set; } = true;

        [ForeignKey("CategoryId")]
        [Column("category_id")]
        public int? CategoryId { get; set; }

        [ForeignKey("UnitId")]
        [Column("unit_id")]
        public int? UnitId { get; set; }

        [ForeignKey("BrandId")]
        [Column("brand_id")]
        public int? BrandId { get; set; }

        public Category? Category { get; set; }

        public Unit? Unit { get; set; }
        public Brand? Brand { get; set; }

        public List<InvoiceDetail> Invoices { get; set;} = [];

    }
}
