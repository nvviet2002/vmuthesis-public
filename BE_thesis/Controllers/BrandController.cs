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
using BE_thesis.Data;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Drawing.Drawing2D;
using BE_thesis.Enum;
using Microsoft.AspNetCore.Authorization;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
    [Authorization]

    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands =  await _context.Brands.ToListAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", brands));
        }


        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound,"NotFound",brand));
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", brand));
        }

        // PUT: api/Brand/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{brandId}")]
        public async Task<IActionResult> PutBrand(int brandId, ApiBrandInput brandInput)
        {
            if (brandId != brandInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad Request", null));
            }
            var brand = _context.Brands.Find(brandId);
            if (brand == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            brand.Name = brandInput.Name ?? brand.Name;
            brand.Address = brandInput.Address ?? brand.Address;
            brand.Origin = brandInput.Origin ?? brand.Origin;
            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!BrandExists(brandId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                       ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", brand));
        }

        // POST: api/Brand
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBrand(ApiBrandInput brandInput)
        {
            var newBrand = new Brand();
            newBrand.Name = brandInput.Name ?? "";
            newBrand.Address = brandInput.Address ?? "";
            newBrand.Origin = brandInput.Origin ?? "";

            _context.Brands.Add(newBrand);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", newBrand));
        }

        // DELETE: api/Brand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", brand));
        }

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.ID == id);
        }
    }
}
