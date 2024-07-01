using BE_thesis.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.InputModel
{
    public class ApiInvoiceDetailInput
    {
        public int ProductID { get; set; }
        public double Amount { get; set; }

        public string? Note { get; set; }

    }
}
