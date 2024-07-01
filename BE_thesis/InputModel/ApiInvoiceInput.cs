using BE_thesis.Enum;
using BE_thesis.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.InputModel
{
    public class ApiInvoiceInput
    {
        public int? ID { get; set; }
        //public double? Discount { get; set; }
        public double? Paid { get; set; }
        public string? Note { get; set; }

        [MaxLength(50)]
        public string? UserID { get; set; }
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        public InvoiceMethod Method { get; set; }

        public List<ApiInvoiceDetailInput>? InvoiceDetails { get; set; }
    }


    public class ApiCreateInvoiceInput
    {
        //public double? Discount { get; set; }
        public double? Paid { get; set; }
        public string? Note { get; set; }
        [MaxLength(50)]
        public string? UserID { get; set; }
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        public InvoiceMethod Method { get; set; }

        public List<ApiInvoiceDetailInput>? InvoiceDetails { get; set; }
    }

}
