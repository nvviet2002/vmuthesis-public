using BE_thesis.Enum;
using BE_thesis.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.OutputModel
{
    public class ApiInvoiceOutput
    {
        public int ID { get; set; }
        public string Identification { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public double Paid { get; set; }
        public double Refund { get; set; }
        public string Bill { get; set; }
        public InvoiceStatus Status { get; set; }
        public InvoiceMethod Method { get; set; }
        public string QRCode { get; set; }
        public string Note { get; set; }
        public string User { get; set; }
        public string Customer { get; set; }
        public List<ApiInvoiceDetailOutput>? InvoiceDetails { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
