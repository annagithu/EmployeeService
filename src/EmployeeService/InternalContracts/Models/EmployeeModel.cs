using EmployeeService.Helpers.Requests;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.InternalContracts.Models
{
    public class EmployeeModel
    { 
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public int? CompanyId { get; set; }
        public PassportModel? Passport{ get; set; }
        public DepartmentModel? Department{ get; set; } 
    }
}

