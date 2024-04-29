using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.InternalContracts.Models
{
    public class EmployeeQueryModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("surname")]
        public string? Surname { get; set; }

        [Column("phone")]
        public string? Phone { get; set; }

        [Column("companyId")]
        public int? CompanyId { get; set; }

        [Column("passportType")]
        public string? PassportType { get; set; }

        [Column("passportNumber")]
        public string? PassportNumber { get; set; }

        [Column("departmentName")]
        public string? DepartmentName { get; set; }

        [Column("departmentPhone")]
        public string? DepartmentPhone { get; set; }

        [Column("employeeid")]
        public int? EmployeeId { get; set; }
    }

}
