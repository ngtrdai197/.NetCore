using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreUsingVsCode.DTO;
using NetCoreUsingVsCode.Models;

namespace NetCoreUsingVsCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IMapper _mapper;

        public EmployeeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var employee = await db.Employees.ToListAsync();
                var employeeMapper = _mapper.Map<IEnumerable<EmployeeDTO>>(employee);
                return Ok(employeeMapper);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
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
                    var employeeMapper = _mapper.Map<EmployeeDTO>(employee);
                    return Ok(employeeMapper);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee(int id, EmployeeDTO e)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    if (!ModelState.IsValid) return BadRequest(ModelState);
                    var employee = await db.Employees.FindAsync(id);
                    if (employee == null)
                    {
                        return NotFound($"Couldn't find a employee of {id}");
                    }
                    _mapper.Map(e, employee);
                    await db.SaveChangesAsync();
                    return Ok(_mapper.Map<EmployeeDTO>(employee));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeDTO e)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }
                    var emp = _mapper.Map<Employee>(e);
                    db.Employees.Add(emp);
                    await db.SaveChangesAsync();
                    return Ok(emp);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
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
                    db.Remove(employee);
                    await db.SaveChangesAsync();
                    return employee;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}