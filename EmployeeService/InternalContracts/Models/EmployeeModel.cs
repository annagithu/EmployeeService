using EmployeeService.Helpers.Requests;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.InternalContracts.Models
{
    public class EmployeeModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string Surname { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("companyId")]
        public int CompanyId { get; set; }

        [Column("passport")]
        public PassportModel Passport{ get; set; }

        [Column("department")]
        public DepartmentModel Department{ get; set; } 
    }
}

