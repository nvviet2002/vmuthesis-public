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
using static System.Runtime.InteropServices.JavaScript.JSType;
using BE_thesis.Enum;
using Microsoft.AspNetCore.Authorization;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
    [Authorization]

    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cates = await _context.Categories.ToListAsync();
            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", cates));
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", category));
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> PutCategory(int categoryId, ApiCategoryInput categoryInput)
        {
            if (categoryId != categoryInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad Request", null));
            }

            var cate = _context.Categories.Find(categoryId);
            if (cate == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            cate.Name = categoryInput.Name ?? cate.Name;
            cate.Description = categoryInput.Description ?? cate.Description;

            _context.Entry(cate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CategoryExists(categoryId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                      ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", cate));
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCategory(ApiCategoryInput categoryInput)
        {
            var newCate = new Category();
            newCate.Name = categoryInput.Name ?? "";
            newCate.Description = categoryInput.Description ?? "";

            _context.Categories.Add(newCate);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", newCate));

        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", category));

        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }
    }
}
