using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeService.InternalContracts.Models
{
    public class PassportModel
    {
        [Column("passportType")]
        public string PassportType { get; set; }

        [Column("passportNumber")]
        public string PassportNumber { get; set; }

        [Column("employeeId")]
        public int EmployeeId { get; set; }
    }
}
