using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_thesis.Context;
using BE_thesis.Model;
using BE_thesis.InputModel;
using BE_thesis.Services;
using BE_thesis.Enum;
using BE_thesis.Data;
using Microsoft.AspNetCore.Authorization;
using BE_thesis.OutputModel;
using Org.BouncyCastle.Asn1.X9;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
    [Authorization]
    public class InvoiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFileManager _fileManager;
        private readonly IQRCodeManager _qrCodeManager;

        public InvoiceController(AppDbContext context, IFileManager fileManager, IQRCodeManager qrCodeManager)
        {
            _context = context;
            _fileManager = fileManager;
            _qrCodeManager = qrCodeManager;
        }

        // GET: api/Invoice
        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _context.Invoices.OrderByDescending(q => q.CreatedAt)
                .Include(q => q.InvoiceDetails).Include(q => q.User)
                .Include(q => q.Customer).ToListAsync();
            var invoiceOutputList = new List<ApiInvoiceOutput>();
            foreach(var invoice in invoices)
            {
                var newInvoiceOutput = MapInvoiceOutput(invoice);
                invoiceOutputList.Add(newInvoiceOutput);
            }
            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", invoiceOutputList));

        }

        // GET: api/Invoice/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice(int id)
        {
            //map invoice
            var invoice = await _context.Invoices.Include(q => q.InvoiceDetails)
                .Include(q=>q.User).Include(q=>q.Customer)
                .Where(q => q.ID == id).AsNoTracking().FirstOrDefaultAsync();
            if (invoice == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }
            foreach (var detail in invoice.InvoiceDetails)
            {
                var product = await _context.Products.Include(q => q.Unit)
                    .Include(q => q.Brand).Include(q => q.Category)
                    .Where(q => q.ID == detail.ProducID).AsNoTracking().FirstOrDefaultAsync();

                detail.Product = product;
            }
            var invoiceOutput = MapInvoiceOutput(invoice);

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", invoiceOutput));
        }

        // PUT: api/Invoice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> PutInvoice(int invoiceId, ApiInvoiceInput invoiceInput)
        {
            if (invoiceId != invoiceInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad request", null));
            }

            var invoice = await _context.Invoices.Include(q=>q.Customer).FirstOrDefaultAsync(q=>q.ID == invoiceId);
            if (invoice == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }
            //check paid >= total
            var invoiceTotal = 0.0;
            var invoiceAmount = 0.0;
            if (invoiceInput.InvoiceDetails != null)
            {
                foreach (var detail in invoiceInput.InvoiceDetails)
                {
                    var product = await _context.Products.Where(q => q.ID == detail.ProductID).FirstOrDefaultAsync();
                    invoiceTotal += product.Price * detail.Amount;
                    invoiceAmount += detail.Amount;
                }
            }
            if (invoiceInput.Paid < invoiceTotal)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "The amount paid must be more than the total bill", null));
            }

            //edit a customer
            invoice.Customer.Name = invoiceInput.CustomerName ?? invoice.Customer.Name;
            _context.Entry(invoice.Customer).State = EntityState.Modified;

            if (invoiceInput.InvoiceDetails != null)
            {
                _context.RemoveRange(invoice.InvoiceDetails);
                //create new invoice detail
                foreach (var detail in invoiceInput.InvoiceDetails)
                {
                    var product = await _context.Products.Where(q => q.ID == detail.ProductID).FirstOrDefaultAsync();
                    var detailTotal = product.Price * detail.Amount;
                    //add new invoice detail
                    var newDetail = new InvoiceDetail();
                    newDetail.Amount = detail.Amount;
                    newDetail.Price = product.Price;
                    newDetail.Total = detailTotal;
                    newDetail.Note = detail.Note ?? "";
                    newDetail.ProducID = product.ID;
                    newDetail.InvoiceID = invoice.ID;
                    _context.Add(newDetail);
                    //minus inventory of product 
                    product.Inventory -= detail.Amount;
                    _context.Entry(product).State = EntityState.Modified;
                }
            }


            invoice.Amount = invoiceAmount;
            invoice.Price = invoiceTotal;
            invoice.Discount = invoice.Discount;
            invoice.Total = invoiceTotal;
            invoice.Paid = invoiceInput.Paid ?? invoice.Paid;
            invoice.Refund = (invoiceInput.Paid ?? invoice.Paid) - invoice.Total;
            invoice.Status = (invoice.Paid >= invoice.Total) ? InvoiceStatus.Finished : InvoiceStatus.Unfinished;
            invoice.Note = invoiceInput.Note ?? invoice.Note;
            invoice.Method = invoiceInput.Method;
            invoice.UserID = invoiceInput.UserID ?? invoice.UserID;

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!InvoiceExists(invoiceId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                       ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }
            return await GetInvoice(invoice.ID);
        }

        // POST: api/Invoice
        [HttpPost]
        public async Task<IActionResult> PostInvoice(ApiCreateInvoiceInput invoiceInput)
        {
            //check paid >= total
            var invoiceTotal = 0.0;
            var invoiceAmount = 0.0;
            if (invoiceInput.InvoiceDetails != null)
            {
                foreach (var detail in invoiceInput.InvoiceDetails)
                {
                    var product = await _context.Products.Where(q => q.ID == detail.ProductID).FirstOrDefaultAsync();
                    invoiceTotal += product.Price * detail.Amount;
                    invoiceAmount += detail.Amount;
                }
            }
            if(invoiceInput.Paid < invoiceTotal)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "The amount paid must be more than the total bill", null));
            }
            try
            {
                //create a new invoice
                var newInvoice = new Invoice();
                newInvoice.Identification = RandomInvoiceID();
                newInvoice.UserID = invoiceInput.UserID ?? _context.Users.FirstOrDefault().Id;
                _context.Invoices.Add(newInvoice);
                //create a customer
                var newCustomer = new Customer();
                newCustomer.Name = invoiceInput.CustomerName;
                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();


                if (invoiceInput.InvoiceDetails != null)
                {
                    foreach (var detail in invoiceInput.InvoiceDetails)
                    {
                        var product = await _context.Products.Where(q => q.ID == detail.ProductID).FirstOrDefaultAsync();
                        //add new invoice detail
                        var newDetail = new InvoiceDetail();
                        newDetail.Amount = detail.Amount;
                        newDetail.Price = product.Price;
                        newDetail.Total = product.Price * detail.Amount;
                        newDetail.Note = detail.Note ?? "";
                        newDetail.ProducID = product.ID;
                        newDetail.InvoiceID = newInvoice.ID;
                        _context.Add(newDetail);
                        //minus inventory of product 
                        product.Inventory -= detail.Amount;
                        _context.Entry(product).State = EntityState.Modified;
                    }
                }


                newInvoice.Amount = invoiceAmount;
                newInvoice.Price = invoiceTotal;
                newInvoice.Discount = 0.0;
                newInvoice.Total = invoiceTotal;
                newInvoice.Paid = invoiceInput.Paid ?? 0.0;
                newInvoice.Refund = (invoiceInput.Paid ?? 0.0) - newInvoice.Total;
                newInvoice.Status = (invoiceInput.Paid >= newInvoice.Total) ? InvoiceStatus.Finished : InvoiceStatus.Unfinished;
                newInvoice.Note = invoiceInput.Note ?? "";
                newInvoice.Method = invoiceInput.Method;
                newInvoice.CustomerID = newCustomer.ID;
                //generate a new qrcode
                var qrCode = await _qrCodeManager.GenerateQRCodeAsync(newInvoice.ID.ToString());
                string qrName = $"{Guid.NewGuid()}" + $"-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                newInvoice.QRCode = await _fileManager.SaveQRFile(qrCode, qrName, "Uploads/Invoice/QRCode");
                _context.Entry(newInvoice).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return await GetInvoice(newInvoice.ID);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
            }
        }

        // DELETE: api/Invoice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.Include(q => q.InvoiceDetails).FirstOrDefaultAsync(q => q.ID == id);
            if (invoice == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }
            foreach (var detail in invoice.InvoiceDetails)
            {
                _context.InvoiceDetails.Remove(detail);
            }
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", null));
        }
        //upload pdf or image
        [HttpPost("bill/{id}")]
        public async Task<IActionResult> UploadBill(int id, IFormFile billFile)
        {
            try
            {
                var invoice = await _context.Invoices.FirstOrDefaultAsync(q=>q.ID == id);
                if (invoice == null)
                {
                    throw new Exception($"Invoice have id = {id} not found");
                }
                string billName = $"{id}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                invoice.Bill = await _fileManager.UploadFile(billFile, billName, "Uploads/Invoice/Bill");
                _context.Invoices.Update(invoice);
                await _context.SaveChangesAsync();

                return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", invoice));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
            }
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.ID == id);
        }

        private string RandomInvoiceID()
        {
            var random = new Random();
            var invoiceId = random.Next(100000, 1000000).ToString();
            if (_context.Invoices.Where(q=>q.Identification.Contains(invoiceId)).FirstOrDefault() != null)
            {
                return RandomInvoiceID();
            }
            return invoiceId;
        }

        private ApiInvoiceOutput MapInvoiceOutput(Invoice invoice)
        {
            var invoiceOuput = new ApiInvoiceOutput()
            {
                ID = invoice.ID,
                Price = invoice.Price,
                Paid = invoice.Paid,
                Note = invoice.Note,
                QRCode = invoice.QRCode,
                Identification = invoice.Identification,
                Discount = invoice.Discount,
                IsDeleted = invoice.IsDeleted,
                CreatedAt = invoice.CreatedAt,
                Amount = invoice.Amount,
                Refund = invoice.Refund,
                Total = invoice.Total,
                Method = invoice.Method,
                Bill = invoice.Bill,
                UpdatedAt = invoice.UpdatedAt,
                Status = invoice.Status,
                Customer = invoice.Customer.Name,
                User = invoice.User.Name,
                InvoiceDetails = new List<ApiInvoiceDetailOutput>()
            };
            //map invoice detail
            foreach (var detail in invoice.InvoiceDetails)
            {
                var invoiceDetailOutput = new ApiInvoiceDetailOutput()
                {
                    ID = detail.ID,
                    Note = detail.Note,
                    Amount = detail.Amount,
                    Price = detail.Price,
                    CreatedAt = detail.CreatedAt,
                    UpdatedAt = detail.UpdatedAt,
                    IsDeleted = detail.IsDeleted,
                    Total = detail.Total,
                };
                if (detail.Product != null)
                {
                    var productOutput = new ApiProductOutput()
                    {
                        ID = detail.Product.ID,
                        Avatar = detail.Product.Avatar,
                        Description = detail.Product.Description,
                        Inventory = detail.Product.Inventory,
                        Identification = detail.Product.Identification,
                        Price = detail.Product.Price,
                        Name = detail.Product.Name,
                        QRCode = detail.Product.QRCode,
                        SKU = detail.Product.SKU,
                        Type = detail.Product.Type,
                        IsDeleted = detail.Product.IsDeleted,
                        CreatedAt = detail.Product.CreatedAt,
                        UpdatedAt = detail.Product.UpdatedAt,
                        Active = detail.Product.Active,
                        Brand = detail.Product.Brand.Name,
                        Unit = detail.Product.Unit.Name,
                        Category = detail.Product.Category.Name
                    };
                    invoiceDetailOutput.Product = productOutput;
                }
                invoiceOuput.InvoiceDetails.Add(invoiceDetailOutput);
            }
            return invoiceOuput;
        }

    }
}
