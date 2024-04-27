using EmployeeService.Helpers.Requests;
using EmployeeService.InternalContracts.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Create employee")]
        public async Task<IActionResult> Create(EmployeeModel model)
        {
            await _employeeService.Create(model);
            return Ok(new { message = "Employee created" });
        }

        [HttpDelete("Delete employee")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok(new { message = "Employee deleted" });
        }

        [HttpGet("Get employees by company id")]
        public async Task<IActionResult> GetByCompanyId(int id)
        {
            var employees = await _employeeService.GetByCompanyId(id);
            return Ok(employees);
        }

        [HttpGet("Get employees by department")]
        public async Task<IActionResult> GetByDepartmentName(string deptName)
        {
            var employees = await _employeeService.GetByDepartmentName(deptName);
            return Ok(employees);
        }

        [HttpPut("Update employee's data")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel model)
        {
            await _employeeService.UpdateEmployee(model);
            return Ok(new { message = "Employee updated" });
        }
    }
}
