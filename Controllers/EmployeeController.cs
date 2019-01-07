using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreUsingVsCode.Models;

namespace NetCoreUsingVsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return await db.Employees.ToListAsync();
            }
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    var employee = await db.Employees.FindAsync(id);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    return employee;
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
    }
}