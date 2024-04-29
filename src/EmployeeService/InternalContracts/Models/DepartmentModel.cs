using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.InternalContracts.Models
{
    public class DepartmentModel
    {
        [Column("departmentName")]
        public string DepartmentName { get; set; }

        [Column("departmentPhone")]
        public string DepartmentPhone { get; set; }
    }
}
