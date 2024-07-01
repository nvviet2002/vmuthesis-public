using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.Model
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail: BaseEntity
    {
        [Column("amount")]
        public double Amount { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("total")]
        public double Total { get; set; }

        [Column("note", TypeName = "nvarchar(200)")]
        public string Note { get; set; } = string.Empty;


        [ForeignKey("ProducID")]
        [Column("product_id")]
        public int? ProducID { get; set; }

        [ForeignKey("InvoiceID")]
        [Column("invoice_id")]
        public int? InvoiceID { get; set; }

        public Product? Product { get; set; }
        public Invoice? Invoice { get; set; }
    }
}
