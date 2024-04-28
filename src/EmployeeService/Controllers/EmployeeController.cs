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

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> Create(EmployeeModel model)
        {
            return Ok(await _employeeService.Create(model));
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok(new { message = "Employee deleted" });
        }

        [HttpGet("GetEmployeesByCompanyId")]
        public async Task<IActionResult> GetByCompanyId(int id)
        {
            var employees = await _employeeService.GetByCompanyId(id);
            return Ok(employees);
        }

        [HttpGet("GetEmployeesByDepartment")]
        public async Task<IActionResult> GetByDepartmentName(int companyId, string deptName)
        {
            var employees = await _employeeService.GetByDepartmentName(companyId, deptName);
            return Ok(employees);
        }

        [HttpPut("UpdateEmployeeData")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel model)
        {
            await _employeeService.UpdateEmployee(model);
            return Ok(new { message = "Employee updated" });
        }
    }
}
