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
using BE_thesis.Enum;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BE_thesis.Services;
using Microsoft.AspNetCore.Identity;
using BE_thesis.Data;
using BE_thesis.OutputModel;
using Microsoft.AspNetCore.Authorization;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
    [Authorization]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IFileManager _fileManager;
        private readonly IQRCodeManager _qrCodeManager;

        public ProductController(AppDbContext context,IFileManager fileManager, IQRCodeManager qrCodeManager)
        {
            _context = context;
            _fileManager = fileManager;
            _qrCodeManager = qrCodeManager;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.Include(q => q.Unit).Include(q => q.Category)
                .Include(q => q.Brand).ToListAsync();
            var productOutputs = new List<ApiProductOutput>();
            foreach(var product in products)
            {
                productOutputs.Add(MappingProduct(product));
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", productOutputs));
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                                        .Include(q => q.Unit).Include(q => q.Category).Include(q => q.Brand)
                                        .FirstOrDefaultAsync(q => q.ID == id);
            
            if (product == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "Not found", null));
            }
            var productOutput = MappingProduct(product);

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", productOutput));
        }
        // GET: api/Product/5
        [HttpGet("identification/{identification}")]
        public async Task<IActionResult> GetProduct(string identification)
        {
            var product = await _context.Products
                                        .Include(q => q.Unit).Include(q => q.Category).Include(q => q.Brand)
                                        .FirstOrDefaultAsync(q => q.Identification.Contains(identification));

            if (product == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "Not found", null));
            }
            var productOutput = MappingProduct(product);

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", productOutput));
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{productId}")]
        public async Task<IActionResult> PutProduct(int productId,[FromForm] ApiProductInput productInput)
        {
            if (productId != productInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad request", null));
            }


            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            product.Name = productInput.Name ?? product.Name;
            product.Description = productInput.Description ?? product.Description;
            product.SKU = productInput.SKU ?? product.SKU;
            product.Type = productInput.Type ?? product.Type;
            product.QRCode = productInput.QRCode ?? product.QRCode;
            //product.Avatar = productInput.Avatar ?? product.Avatar;
            product.Inventory = productInput.Inventory ?? product.Inventory;
            product.Price = productInput.Price ?? product.Price;
            product.Active = productInput.Active ?? product.Active;
            product.CategoryId = productInput.CategoryId ?? product.CategoryId;
            product.BrandId = productInput.BrandId ?? product.BrandId;
            product.UnitId = productInput.UnitId ?? product.UnitId;

            if (productInput.Avatar != null)
            {
                string avatarName = $"{Guid.NewGuid()}" +
                    $"-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                product.Avatar = await _fileManager.UploadFile(productInput.Avatar, avatarName,"Uploads/Product/Avatar");
            }


            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductExists(productId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, ex.Message, null));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", product));
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromForm] ApiProductInput productInput)
        {
            try
            {
                var newProduct = new Product();
                newProduct.Identification = RandomProductID();
                newProduct.Name = productInput.Name ?? "";
                newProduct.Description = productInput.Description ?? "";
                newProduct.SKU = productInput.SKU ?? "";
                newProduct.Type = productInput.Type ?? ProductType.Code;
                newProduct.QRCode = productInput.QRCode ?? "";
                newProduct.Inventory = productInput.Inventory ?? 0.0;
                newProduct.Price = productInput.Price ?? 0.0;
                newProduct.Active = productInput.Active ?? true;
                newProduct.CategoryId = productInput.CategoryId;
                newProduct.BrandId = productInput.BrandId;
                newProduct.UnitId = productInput.UnitId;
                //handle Avatar
                if (productInput.Avatar == null)
                {
                    newProduct.Avatar = "";
                }
                else
                {
                    string avatarName = $"{Guid.NewGuid()}" +
                        $"-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                    newProduct.Avatar = await _fileManager.UploadFile(productInput.Avatar, avatarName, "Uploads/Product/Avatar");
                }


                _context.Products.Add(newProduct);
                await _context.SaveChangesAsync();

                //Handle QRCode
                var qrCode = await _qrCodeManager.GenerateQRCodeAsync(newProduct.ID.ToString());
                string qrName = $"{Guid.NewGuid()}" + $"-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
                newProduct.QRCode = await _fileManager.SaveQRFile(qrCode, qrName, "Uploads/Product/QRCode");
                return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", newProduct));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
            }

            
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", product));
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", null));
        }

        // GET: api/Product/search
        [HttpGet("search")]
        public async Task<IActionResult> GetProducts(string? searchText)
        {
            searchText = searchText ?? "";
            var products = await _context.Products.Include(q=>q.Unit).Include(q=>q.Category).Include(q=>q.Brand)
                .Where(q=>q.Name.Contains(searchText) && q.Type == ProductType.Weight).AsNoTracking().ToListAsync();
            var productOutputs = new List<ApiProductOutput>();
            foreach (var product in products)
            {
                productOutputs.Add(MappingProduct(product));
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", productOutputs));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
        private ApiProductOutput MappingProduct(Product product)
        {
            var productOutput = new ApiProductOutput()
            {
                ID = product.ID,
                Name = product.Name,
                Description = product.Description,
                Inventory = product.Inventory,
                Identification = product.Identification,
                Price = product.Price,
                SKU = product.SKU,
                QRCode = product.QRCode,
                Type = product.Type,
                Avatar = product.Avatar,
                Active = product.Active,
                Unit = product.Unit.Name,
                Category = product.Category.Name,
                Brand = product.Brand.Name,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                IsDeleted = product.IsDeleted,

            };
            return productOutput;
        }

        private string RandomProductID()
        {
            var random = new Random();
            var productId = random.Next(100000, 1000000).ToString();
            if (_context.Products.Where(q => q.Identification.Contains(productId)).FirstOrDefault() != null)
            {
                return RandomProductID();
            }
            return productId;
        }


    }
}
