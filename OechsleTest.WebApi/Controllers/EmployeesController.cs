using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OechsleTest.WebApi.Data;
using OechsleTest.WebApi.Models;

namespace OechsleTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataApiContext _context;

        public EmployeesController(DataApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            return await _context.Employee.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpGet("bydocument/{document}")]
        public async Task<ActionResult<Employee>> GetByDocument(string document)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            if (document.Trim().Length > 8)
                return NotFound(new { Message = $"The document ({document}) must contain a maximum of 8 digits." });

            var employee = await _context.Employee.Where(c => c.document_number == document).FirstOrDefaultAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Insert(Employee employee)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'DataApiContext.Employee'  is null.");
            }
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.id }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}