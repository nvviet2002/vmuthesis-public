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
using BE_thesis.Enum;
using Microsoft.AspNetCore.Authorization;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
    [Authorization]
    public class UnitController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnitController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Unit
        [HttpGet]
        public async Task<IActionResult> GetUnits()
        {
            var cates = await _context.Units.ToListAsync();
            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", cates));

        }

        // GET: api/Unit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);

            if (unit == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", unit));

        }

        // PUT: api/Unit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{unitId}")]
        public async Task<IActionResult> PutUnit(int unitId, ApiUnitInput unitInput)
        {
            if (unitId != unitInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad Request", null));

            }

            var unit = _context.Units.Find(unitId);
            if (unit == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));
            }

            unit.Name = unitInput.Name ?? unit.Name;
            unit.Description = unitInput.Description ?? unit.Description;

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UnitExists(unitId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", unit));

        }

        // POST: api/Unit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUnit(ApiUnitInput unitInput)
        {

            var newUnit = new Unit();
            newUnit.Name = unitInput.Name ?? "";
            newUnit.Description = unitInput.Description ?? "";

            _context.Units.Add(newUnit);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", newUnit));

        }

        // DELETE: api/Unit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

            }

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", unit));

        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.ID == id);
        }
    }
}
