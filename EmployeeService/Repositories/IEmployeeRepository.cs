using EmployeeService.InternalContracts.Models;

namespace EmployeeService.Repositories
{
    public interface IEmployeeRepository
    {
        Task Create(EmployeeModel employeeModel);

        Task <EmployeeQueryModel> GetById(int id);

        Task DeleteEmployee(int id);

        Task<List<EmployeeModel>>GetByCompanyId(int id);

        Task<List<EmployeeModel>> GetByDepartmentName(string deptName);

        Task UpdateEmployee(EmployeeModel employeeModel);

    }
}
