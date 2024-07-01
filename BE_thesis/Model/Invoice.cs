using BE_thesis.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.Model
{
    [Table("Invoice")]
    public class Invoice: BaseEntity
    {

        [Column("identification")]
        [Index(IsUnique =true)]
        public string Identification { get; set; } = "";

        [Column("amount")]
        public double Amount { get; set; } = 0.0;
        [Column("price")]
        public double Price { get; set; } = 0.0;
        [Column("discount")]
        public double Discount { get; set; } = 0.0;
        [Column("total")]
        public double Total { get; set; } = 0.0;
        [Column("paid")]
        public double Paid { get; set; } = 0.0;
        [Column("refund")]
        public double Refund { get; set; } = 0.0;

        [Column("status")]
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Unfinished;
        [Column("method")]
        public InvoiceMethod Method { get; set; } = InvoiceMethod.Cash;
        [Column("bill")]
        public string Bill { get; set; } = string.Empty;

        [Column("qr_code",TypeName = "nvarchar(MAX)")]
        public string QRCode { get; set; } = string.Empty;

        [Column("note", TypeName = "nvarchar(200)")]
        public string Note { get; set; } = string.Empty;

        [ForeignKey("UserID")]
        [Column("user_id")]
        public string UserID { get; set; } = string.Empty;

        [ForeignKey("CustomerID")]
        [Column("customer_id")]
        public int? CustomerID { get; set; }

        public User? User { get; set; }

        public Customer? Customer { get; set; }

        public List<InvoiceDetail>? InvoiceDetails { get; set; } = [];
    }
}
