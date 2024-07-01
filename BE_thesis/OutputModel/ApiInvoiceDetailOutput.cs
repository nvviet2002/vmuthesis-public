using BE_thesis.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_thesis.OutputModel
{
    public class ApiInvoiceDetailOutput
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public string Note { get; set; }
        public ApiProductOutput? Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
