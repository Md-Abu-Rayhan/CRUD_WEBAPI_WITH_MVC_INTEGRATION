using EmployeeAPI.Models;
using EmployeeAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        // Get all employees
        [HttpGet("getall")]
        public ActionResult<List<Employee>> GetAll()
        {
            return _repository.GetEmployees(null);
        }

        // Insert a new employee
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Employee employee)
        {
            _repository.AddEmployee(employee);
            return Ok(new { message = "Employee added successfully!" });
        }

        // Update an existing employee
        [HttpPut("update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            _repository.UpdateEmployee(employee);
            return Ok(new { message = "Employee updated successfully!" });
        }

        // Delete an employee by Id
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteEmployee(id);
            return Ok(new { message = "Employee deleted successfully!" });
        }
    }
}
